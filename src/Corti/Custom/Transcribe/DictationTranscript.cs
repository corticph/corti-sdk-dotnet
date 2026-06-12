namespace Corti;

/// <summary>
/// Represents the current state of a dictation transcript session.
/// Round-trip the whole snapshot as <c>previous</c> — it carries opaque finalized-span
/// state required for race-condition guards.
/// </summary>
public sealed record DictationTranscriptSnapshot
{
    /// <summary>
    /// Finalized text only. Use this for copy, clear, and JSON export.
    /// </summary>
    public required string CommittedText { get; init; }

    /// <summary>
    /// Active interim preview. Empty string when none.
    /// Includes its leading boundary space so the UI can render it verbatim
    /// immediately after <see cref="CommittedText"/>.
    /// </summary>
    public required string InterimText { get; init; }

    /// <summary>Internal: set of start values that have been finalized.</summary>
    internal HashSet<double> FinalizedStarts { get; init; } = new();

    /// <summary>Internal: maximum end value over all finalized segments.</summary>
    internal double LatestFinalEnd { get; init; } = double.NegativeInfinity;
}

/// <summary>
/// Pure utility for assembling dictation transcript packets into a two-layer
/// committed + interim text model (DXG-844) with race-condition guards (DXG-1093).
/// </summary>
public static class DictationTranscript
{
    private static readonly HashSet<char> NoSpaceAfter = new()
    {
        '(', '[', '{', '"', '\'', '\u2018', '\u201c',
    };

    private static readonly HashSet<char> LeftAttach = new()
    {
        ',', '.', ':', ';', '!', '?', ')', ']', '}', '%',
    };

    /// <summary>
    /// Applies a single transcript message to the previous snapshot and returns a new
    /// snapshot with updated committed/interim text.
    /// </summary>
    /// <param name="previous">The last snapshot, or <c>null</c> on first call.</param>
    /// <param name="message">The incoming transcript packet.</param>
    public static DictationTranscriptSnapshot Apply(
        DictationTranscriptSnapshot? previous,
        TranscribeTranscriptData message)
    {
        var committedText = previous?.CommittedText ?? string.Empty;
        var finalizedStarts = previous?.FinalizedStarts ?? new HashSet<double>();
        var latestFinalEnd = previous?.LatestFinalEnd ?? double.NegativeInfinity;

        if (message.IsFinal)
        {
            if (finalizedStarts.Contains(message.Start))
            {
                // R5: duplicate final — fully idempotent; do not touch interim (a newer
                // interim for a different span may be in flight).
                return previous!;
            }

            var nextFinalizedStarts = new HashSet<double>(finalizedStarts) { message.Start };
            var newCommitted = committedText + BuildInsertion(committedText, message.Text);

            return new DictationTranscriptSnapshot
            {
                CommittedText = newCommitted,
                InterimText = string.Empty,
                FinalizedStarts = nextFinalizedStarts,
                LatestFinalEnd = Math.Max(latestFinalEnd, message.End),
            };
        }

        // Interim path.
        if (finalizedStarts.Contains(message.Start))
        {
            return previous ?? EmptySnapshot();
        }

        if (message.Start < latestFinalEnd)
        {
            return previous ?? EmptySnapshot();
        }

        return new DictationTranscriptSnapshot
        {
            CommittedText = committedText,
            InterimText = BuildInsertion(committedText, message.Text),
            FinalizedStarts = finalizedStarts,
            LatestFinalEnd = latestFinalEnd,
        };
    }

    /// <summary>
    /// Returns <paramref name="segment"/> prefixed with at most one space, applying
    /// punctuation-aware boundary rules so callers never produce double-spaces or
    /// spaces before attachment characters.
    /// </summary>
    private static string BuildInsertion(string committed, string segment)
    {
        if (segment.Length == 0)
            return segment;

        var prevChar = committed.Length > 0 ? committed[^1] : '\0';
        var nextChar = segment[0];

        var needsSpace =
            committed.Length > 0
            && !char.IsWhiteSpace(prevChar)
            && !NoSpaceAfter.Contains(prevChar)
            && !LeftAttach.Contains(nextChar);

        return needsSpace ? $" {segment}" : segment;
    }

    private static DictationTranscriptSnapshot EmptySnapshot() =>
        new()
        {
            CommittedText = string.Empty,
            InterimText = string.Empty,
        };
}

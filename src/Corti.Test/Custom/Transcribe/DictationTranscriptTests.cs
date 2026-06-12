using Corti;
using NUnit.Framework;

namespace Corti.Test.Custom.Transcribe;

[TestFixture]
public class DictationTranscriptTests
{
    // -------------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------------

    private static TranscribeTranscriptData Msg(
        string text,
        double start,
        double end,
        bool isFinal) =>
        new()
        {
            Text = text,
            RawTranscriptText = text,
            Start = start,
            End = end,
            IsFinal = isFinal,
        };

    // -------------------------------------------------------------------------
    // Boundary spacing (S1–S6)
    // -------------------------------------------------------------------------

    [Test]
    public void Spacing_EmptyField_NoLeadingSpace()
    {
        var snap = DictationTranscript.Apply(null, Msg("Hello", 0, 1, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("Hello"));
    }

    [Test]
    public void Spacing_AfterColon_LeadingSpace()
    {
        var snap = DictationTranscript.Apply(null, Msg("Assessment:", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg("mild pain", 2, 3, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("Assessment: mild pain"));
    }

    [Test]
    public void Spacing_AfterOpenParen_NoLeadingSpace()
    {
        var snap = DictationTranscript.Apply(null, Msg("Pain (", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg("mild", 2, 3, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("Pain (mild"));
    }

    [Test]
    public void Spacing_BeforeComma_NoLeadingSpace()
    {
        var snap = DictationTranscript.Apply(null, Msg("No", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg(",", 2, 3, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("No,"));
    }

    [Test]
    public void Spacing_AfterWhitespace_NoLeadingSpace()
    {
        var snap = DictationTranscript.Apply(null, Msg("Hello ", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg("world", 2, 3, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("Hello world"));
    }

    // -------------------------------------------------------------------------
    // Interim → final flow (I1–I2)
    // -------------------------------------------------------------------------

    [Test]
    public void InterimThenFinal_CommittedGrowsInterimCleared()
    {
        var snap = DictationTranscript.Apply(null, Msg("pain", 0, 0.5, isFinal: false));

        Assert.That(snap.CommittedText, Is.EqualTo(string.Empty));
        Assert.That(snap.InterimText, Is.EqualTo("pain"));

        snap = DictationTranscript.Apply(snap, Msg("pain.", 0, 1, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("pain."));
        Assert.That(snap.InterimText, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Interim_AfterCommitted_IncludesLeadingSpace()
    {
        // S6 + I1: interim after "Assessment:" should have a leading space in interimText
        var snap = DictationTranscript.Apply(null, Msg("Assessment:", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg("mild", 2, 2.5, isFinal: false));

        Assert.That(snap.CommittedText, Is.EqualTo("Assessment:"));
        Assert.That(snap.InterimText, Is.EqualTo(" mild"));
    }

    // -------------------------------------------------------------------------
    // Two interims — only latest in interimText (I3)
    // -------------------------------------------------------------------------

    [Test]
    public void TwoInterims_OnlyLatestKept()
    {
        var snap = DictationTranscript.Apply(null, Msg("pa", 0, 0.3, isFinal: false));
        snap = DictationTranscript.Apply(snap, Msg("pain", 0, 0.6, isFinal: false));

        Assert.That(snap.CommittedText, Is.EqualTo(string.Empty));
        Assert.That(snap.InterimText, Is.EqualTo("pain"));
    }

    // -------------------------------------------------------------------------
    // Race conditions — same-span (R2, R5)
    // -------------------------------------------------------------------------

    [Test]
    public void FinalThenInterimSameStart_Unchanged()
    {
        var snap = DictationTranscript.Apply(null, Msg("pain.", 0, 1, isFinal: true));
        var after = DictationTranscript.Apply(snap, Msg("pain period", 0, 1, isFinal: false));

        Assert.That(after.CommittedText, Is.EqualTo("pain."));
        Assert.That(after.InterimText, Is.EqualTo(string.Empty));
    }

    [Test]
    public void DuplicateFinal_NoDoubleAppend()
    {
        var snap = DictationTranscript.Apply(null, Msg("pain.", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg("pain.", 0, 1, isFinal: true));

        Assert.That(snap.CommittedText, Is.EqualTo("pain."));
    }

    [Test]
    public void DuplicateFinal_InterimForNewerSpanPreserved()
    {
        // Interim for span 2 is in flight; duplicate final for the earlier span 0 arrives.
        // The newer interim must not be wiped.
        var snap = DictationTranscript.Apply(null, Msg("pain.", 0, 1, isFinal: true));
        snap = DictationTranscript.Apply(snap, Msg("mild", 2, 2.5, isFinal: false));
        snap = DictationTranscript.Apply(snap, Msg("pain.", 0, 1, isFinal: true)); // duplicate

        Assert.That(snap.CommittedText, Is.EqualTo("pain."));
        Assert.That(snap.InterimText, Is.EqualTo(" mild"));
    }

    // -------------------------------------------------------------------------
    // Race conditions — cross-span (R-cross: start < latestFinalEnd)
    // -------------------------------------------------------------------------

    [Test]
    public void LateInterim_OverlappingFinalizedTimeline_Unchanged()
    {
        // Final committed for span 0–2; late interim arrives for start=1 (< latestFinalEnd=2).
        var snap = DictationTranscript.Apply(null, Msg("pain.", 0, 2, isFinal: true));
        var after = DictationTranscript.Apply(snap, Msg("pain period", 1, 1.5, isFinal: false));

        Assert.That(after.CommittedText, Is.EqualTo("pain."));
        Assert.That(after.InterimText, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Interim_StartEqualsLatestFinalEnd_Accepted()
    {
        // start == latestFinalEnd is NOT considered overlapping (strictly <).
        var snap = DictationTranscript.Apply(null, Msg("pain.", 0, 2, isFinal: true));
        var after = DictationTranscript.Apply(snap, Msg("mild", 2, 2.5, isFinal: false));

        Assert.That(after.InterimText, Is.EqualTo(" mild"));
    }
}

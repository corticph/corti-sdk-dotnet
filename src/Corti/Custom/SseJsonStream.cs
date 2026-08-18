using Corti.Core;
using global::System.Net.ServerSentEvents;
using global::System.Runtime.CompilerServices;
using global::System.Text.Json;

namespace Corti;

internal static class SseJsonStream
{
    internal static async IAsyncEnumerable<T> ReadEventsAsync<T>(
        ApiResponse response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (
            var item in SseParser
                .Create(await response.Raw.Content.ReadAsStreamAsync())
                .EnumerateAsync(cancellationToken)
        )
        {
            if (string.IsNullOrEmpty(item.Data))
            {
                continue;
            }

            T? result;
            try
            {
                result = JsonUtils.Deserialize<T>(item.Data);
            }
            catch (JsonException)
            {
                throw new CortiClientException(
                    $"Unable to deserialize JSON response 'item.Data'"
                );
            }
            yield return result!;
        }
    }
}

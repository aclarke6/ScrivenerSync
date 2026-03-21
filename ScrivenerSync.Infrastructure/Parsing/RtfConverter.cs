using System.Security.Cryptography;
using System.Text;
using RtfPipe;

namespace ScrivenerSync.Infrastructure.Parsing;

public class RtfConverter
{
    /// <summary>
    /// Returns the expected path to a Scrivener document's RTF file.
    /// </summary>
    public string GetContentPath(string scrivFolderPath, string uuid) =>
        Path.Combine(scrivFolderPath, "Files", "Data", uuid, "content.rtf");

    /// <summary>
    /// Reads and converts the RTF content for the given UUID.
    /// Returns null if no content.rtf file exists (folder nodes, empty documents).
    /// </summary>
    public async Task<RtfConversionResult?> ConvertAsync(
        string scrivFolderPath,
        string uuid,
        CancellationToken ct = default)
    {
        var path = GetContentPath(scrivFolderPath, uuid);

        if (!File.Exists(path))
            return null;

        var rtfBytes = await File.ReadAllBytesAsync(path, ct);

        if (rtfBytes.Length == 0)
            return null;

        var html  = ConvertRtfToHtml(rtfBytes);
        var hash  = ComputeHash(rtfBytes);

        return new RtfConversionResult
        {
            Html = html,
            Hash = hash
        };
    }

    // ---------------------------------------------------------------------------
    // Private helpers
    // ---------------------------------------------------------------------------

    private static string ConvertRtfToHtml(byte[] rtfBytes)
    {
        var rtfText = Encoding.UTF8.GetString(rtfBytes);
        return Rtf.ToHtml(rtfText);
    }

    private static string ComputeHash(byte[] content)
    {
        var hashBytes = SHA256.HashData(content);
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}

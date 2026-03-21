namespace ScrivenerSync.Infrastructure.Parsing;

public sealed class RtfConversionResult
{
    public string Html { get; init; } = default!;
    public string Hash { get; init; } = default!;
}

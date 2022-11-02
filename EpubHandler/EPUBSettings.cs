
using System.ComponentModel.DataAnnotations;

public record EPUBSettings
{
    [Required]
    public string? OutputDirectory { get; set; }

    public string? ContentSource { get; set; }

    public string? Title { get; set; }

    public string? Language { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public List<string>? Tags { get; set; }

    public bool Multiple { get; set; }

    public string? CoverPhoto { get; set; }

    public long Compression { get; set; } = 20L;
}


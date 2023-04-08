using Microsoft.Build.Framework;

namespace MovieStoreMVC.Models.Domain;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? ReleaseYear { get; set; }
    public string? MovieImage { get; set; } //stored movies image name with extension(eg: image0001.jpg)
    public string? Cast { get; set; }
    [Required]
    public string? Director { get; set; }
}

namespace ProjektZaliczeniowy.Models.ViewModels;

public class MovieViewModel
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public double? Popularity { get; set; }
    public long? Revenue { get; set; }
    public int? Runtime { get; set; }
    public double? VoteAverage { get; set; }
    public int? VoteCount { get; set; }
}
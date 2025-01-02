namespace API.Dtos.Algorithm;

public class AlgorithmListDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; }
    public string[] Tags { get; set; }
    public int VisualizationsCount { get; set; }
}

namespace API.Persistence.Entities;

public class Algorithm
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CourseId { get; set; }

    public Course Course { get; set; }
    public ICollection<Visualization> Visualizations { get; set; } = [];
    public ICollection<Tag> Tags { get; set; } = [];
}

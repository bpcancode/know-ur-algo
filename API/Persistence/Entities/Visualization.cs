using System.Security.Cryptography;

namespace API.Persistence.Entities;

public class Visualization
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Html { get; set; } 
    public string Css { get; set; }
    public string Js { get; set; }
    public int AlgorithmId { get; set; }
    public int UserId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public int VoteCount { get; set; } = 0;

    public User User { get; set; }
    public Algorithm Algorithm { get; set; }
    public ICollection<Vote> Votes { get; set; } = new List<Vote>();
}

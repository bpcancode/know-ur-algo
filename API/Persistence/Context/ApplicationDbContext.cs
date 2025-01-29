using API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Visualization> Visualizations { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<Algorithm> Algorithms { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSeeding((context, _) =>
        {
            List<User> users = [
                new () { Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin", 12) , Role = "Admin" },
                new () { Username = "john_doe", Password = BCrypt.Net.BCrypt.HashPassword("user", 12) , Role = "User" },
                new () { Username = "hari", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
                new () { Username = "bishal", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
                new () { Username = "arun", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
                new () { Username = "madhuri", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
            ];

            List<Algorithm> algorithms = [
                new () { Title = "Bubble Sort"},
                new () { Title = "Quick Sort"},
                new () { Title = "Merge Sort"},
                new () { Title = "Insertion Sort"},
                new () { Title = "Selection Sort"},
                new () { Title = "Heap Sort" },
                new () { Title = "Radix Sort" },
            ];

            Random ran = new Random();
            



            List<Visualization> visualizationsUser1 = [
                new () { Algorithm=algorithms[0], User=users[0], Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');", Views = ran.Next(10,500) , Votes=[new(){User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[1], User=users[0], Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[1] }, new() { User = users[2] }, new() { User = users[3] }, new() { User = users[4] }]},
                new () { Algorithm=algorithms[2], User=users[0], Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }, new() { User = users[4] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[0], Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[4] }, new() { User = users[3] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[0], Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Views = ran.Next(10,500), Votes=[ new() { User = users[5] }] },
                new () { Algorithm=algorithms[5], User=users[0], Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Views = ran.Next(10,500), Votes=[new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[0], Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }] },
            ];

            List<Visualization> visualizationsUser2 = [
                new () { Algorithm=algorithms[0], User=users[1], Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] },  new() { User = users[3] }] },
                new () { Algorithm=algorithms[1], User=users[1], Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Views = ran.Next(10,500), Votes=[ new() { User = users[4] }] },
                new () { Algorithm=algorithms[2], User=users[1], Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[1] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[3], User=users[1], Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[5] }, new() { User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[4], User=users[1], Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[5], User=users[1], Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Views = ran.Next(10,500), Votes=[ new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[6], User=users[1], Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },

            ];

            List<Visualization> visualizationsUser3 = [
                new () { Algorithm=algorithms[0], User=users[2],  Views = ran.Next(10,500),  Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');" , Votes=[new(){User = users[0] },  new() { User = users[3] }, new() { User = users[2] }]  },
                new () { Algorithm=algorithms[1], User=users[2],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[2],  Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[3] }, new() { User = users[1] }] },
                new () { Algorithm=algorithms[3], User=users[2],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[3] }] },
                new () { Algorithm=algorithms[4], User=users[2],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[3] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[2],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[3] }] },
                new () { Algorithm=algorithms[6], User=users[2],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');", Votes=[new(){User = users[2] },  new() { User = users[3] }, new() { User = users[4] }] },
            ];

            List<Visualization> visualizationsUser4 = [
                new () { Algorithm=algorithms[0], User=users[3],  Views = ran.Next(10,500), Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[1], User=users[3],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[3],  Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[3],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[3],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[3],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[3],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
            ];

            List<Visualization> visualizationsUser5 = [
                new () { Algorithm=algorithms[0], User=users[4],  Views = ran.Next(10,500), Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[1], User=users[4],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[4], Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[4],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[4],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[4],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[4],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
            ];

            List<Visualization> visualizationsUser6 = [
                new () { Algorithm=algorithms[0], User=users[5],  Views = ran.Next(10,500), Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[1], User=users[5],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[5],  Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[5],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[5],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[5],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[5],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
            ];

            var visualization = context.Set<Visualization>().FirstOrDefault();
            if(visualization is null)
            {
                context.Set<Visualization>().AddRange(visualizationsUser1);
                context.Set<Visualization>().AddRange(visualizationsUser2);
                context.Set<Visualization>().AddRange(visualizationsUser3);
                context.Set<Visualization>().AddRange(visualizationsUser4);
                context.Set<Visualization>().AddRange(visualizationsUser5);
                context.Set<Visualization>().AddRange(visualizationsUser6);
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {

            List<User> users = [
               new () { Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin", 12) , Role = "Admin" },
                new () { Username = "john_doe", Password = BCrypt.Net.BCrypt.HashPassword("user", 12) , Role = "User" },
                new () { Username = "hari", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
                new () { Username = "bishal", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
                new () { Username = "arun", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
                new () { Username = "madhuri", Password = BCrypt.Net.BCrypt.HashPassword("user", 12), Role = "User" },
            ];

            List<Algorithm> algorithms = [
                new () { Title = "Bubble Sort"},
                new () { Title = "Quick Sort"},
                new () { Title = "Merge Sort"},
                new () { Title = "Insertion Sort"},
                new () { Title = "Selection Sort"},
                new () { Title = "Heap Sort" },
                new () { Title = "Radix Sort" },
            ];

            Random ran = new Random();

            List<Visualization> visualizationsUser1 = [
                new () { Algorithm=algorithms[0], User=users[0], Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');", Views = ran.Next(10,500) , Votes=[new(){User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[1], User=users[0], Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[1] }, new() { User = users[2] }, new() { User = users[3] }, new() { User = users[4] }]},
                new () { Algorithm=algorithms[2], User=users[0], Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }, new() { User = users[4] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[0], Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[4] }, new() { User = users[3] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[0], Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Views = ran.Next(10,500), Votes=[ new() { User = users[5] }] },
                new () { Algorithm=algorithms[5], User=users[0], Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Views = ran.Next(10,500), Votes=[new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[0], Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }] },
            ];

            List<Visualization> visualizationsUser2 = [
                new () { Algorithm=algorithms[0], User=users[1], Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] },  new() { User = users[3] }] },
                new () { Algorithm=algorithms[1], User=users[1], Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Views = ran.Next(10,500), Votes=[ new() { User = users[4] }] },
                new () { Algorithm=algorithms[2], User=users[1], Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[1] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[3], User=users[1], Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[5] }, new() { User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[4], User=users[1], Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[5], User=users[1], Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Views = ran.Next(10,500), Votes=[ new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },
                new () { Algorithm=algorithms[6], User=users[1], Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Views = ran.Next(10,500), Votes=[new(){User = users[0] }, new() { User = users[1] }, new() { User = users[2] }, new() { User = users[4] }] },

            ];

            List<Visualization> visualizationsUser3 = [
                new () { Algorithm=algorithms[0], User=users[2],  Views = ran.Next(10,500),  Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');" , Votes=[new(){User = users[0] },  new() { User = users[3] }, new() { User = users[2] }]  },
                new () { Algorithm=algorithms[1], User=users[2],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[2],  Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[3] }, new() { User = users[1] }] },
                new () { Algorithm=algorithms[3], User=users[2],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[3] }] },
                new () { Algorithm=algorithms[4], User=users[2],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[3] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[2],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');", Votes=[new(){User = users[0] },  new() { User = users[3] }] },
                new () { Algorithm=algorithms[6], User=users[2],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');", Votes=[new(){User = users[2] },  new() { User = users[3] }, new() { User = users[4] }] },
            ];

            List<Visualization> visualizationsUser4 = [
                new () { Algorithm=algorithms[0], User=users[3],  Views = ran.Next(10,500), Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[1], User=users[3],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[3],  Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[3],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[3],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[3],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[3],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
            ];

            List<Visualization> visualizationsUser5 = [
                new () { Algorithm=algorithms[0], User=users[4],  Views = ran.Next(10,500), Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[1], User=users[4],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[4], Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[4],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[4],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[4],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[4],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
            ];

            List<Visualization> visualizationsUser6 = [
                new () { Algorithm=algorithms[0], User=users[5],  Views = ran.Next(10,500), Title = "Bubble Sort Visualization", Html = "<h1>Bubble Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Bubble Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[1], User=users[5],  Views = ran.Next(10,500), Title = "Quick Sort Visualization", Html = "<h1>Quick Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Quick Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[2], User=users[5],  Views = ran.Next(10,500), Title = "Merge Sort Visualization", Html = "<h1>Merge Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Merge Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[3], User=users[5],  Views = ran.Next(10,500), Title = "Insertion Sort Visualization", Html = "<h1>Insertion Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Insertion Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[4], User=users[5],  Views = ran.Next(10,500), Title = "Selection Sort Visualization", Html = "<h1>Selection Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Selection Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[5], User=users[5],  Views = ran.Next(10,500), Title = "Heap Sort Visualization", Html = "<h1>Heap Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Heap Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
                new () { Algorithm=algorithms[6], User=users[5],  Views = ran.Next(10,500), Title = "Radix Sort Visualization", Html = "<h1>Radix Sort Visualization</h1>", Css = "h1 { color: red; }", Js = "console.log('Radix Sort Visualization');",  Votes=[new(){User = users[0] },  new() { User = users[5] }, new() { User = users[2] }] },
            ];

            var visualization = context.Set<Visualization>().FirstOrDefault();
            if (visualization is null)
            {
                await context.Set<Visualization>().AddRangeAsync(visualizationsUser1, cancellationToken);
                await context.Set<Visualization>().AddRangeAsync(visualizationsUser2, cancellationToken);
                await context.Set<Visualization>().AddRangeAsync(visualizationsUser3, cancellationToken);
                await context.Set<Visualization>().AddRangeAsync(visualizationsUser4, cancellationToken);
                await context.Set<Visualization>().AddRangeAsync(visualizationsUser5, cancellationToken);
                await context.Set<Visualization>().AddRangeAsync(visualizationsUser6, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
            
        });
}

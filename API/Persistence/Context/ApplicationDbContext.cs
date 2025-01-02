using API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Visualization> Visualizations { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSeeding((context, _) =>
        {
            var testBlog = context.Set<User>().FirstOrDefault();
            if (testBlog == null)
            {
                context.Set<User>().Add(new User {Username="bishal", Password= "$2a$12$ts.Zth9ExVhCADk8BSUDleKjduJGkziBy9w4XhG7Ptm8/iuIcp2iG", Role="Admin"});
                context.SaveChanges();
            }

            var tag = context.Set<Tag>().FirstOrDefault();
            if (tag == null)
            {
                List<Tag> tags = [
                    new Tag { Name = "Searching" },
                    new Tag { Name = "Sorting" },
                    new Tag { Name = "Graph" },
                    new Tag { Name = "Tree" },
                    new Tag { Name = "Dynamic Programming" },
                    new Tag { Name = "Greedy" },
                    new Tag { Name = "Backtracking" },
                    new Tag { Name = "Bit Manipulation" },
                    new Tag { Name = "Math" },
                    new Tag { Name = "String" },
                    new Tag { Name = "Array" },
                    new Tag { Name = "Matrix" },
                    new Tag { Name = "Hashing" },
                    new Tag { Name = "Stack" },
                    new Tag { Name = "Queue" },
                    new Tag { Name = "Heap" },
                    new Tag { Name = "Graph" },
                    new Tag { Name = "Linked List" },
                    new Tag { Name = "Binary Search" },
                    new Tag { Name = "Two Pointer" },
                    new Tag { Name = "Sliding Window" },
                    new Tag { Name = "Divide and Conquer" },
                    new Tag { Name = "Breadth First Search" },
                    new Tag { Name = "Depth First Search" },
                    new Tag { Name = "Topological Sort" },
                    new Tag { Name = "Trie" },
                    ];
                context.Set<Tag>().AddRange(tags);
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var testBlog = await context.Set<User>().FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (testBlog == null)
            {
                await context.Set<User>().AddAsync(new User {Username="bishal", Password= "$2a$12$ts.Zth9ExVhCADk8BSUDleKjduJGkziBy9w4XhG7Ptm8/iuIcp2iG", Role="Admin"}, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }

            var tag = await context.Set<Tag>().FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (tag == null)
            {
                List<Tag> tags = [
                    new Tag { Name = "Searching" },
                    new Tag { Name = "Sorting" },
                    new Tag { Name = "Graph" },
                    new Tag { Name = "Tree" },
                    new Tag { Name = "Dynamic Programming" },
                    new Tag { Name = "Greedy" },
                    new Tag { Name = "Backtracking" },
                    new Tag { Name = "Bit Manipulation" },
                    new Tag { Name = "Math" },
                    new Tag { Name = "String" },
                    new Tag { Name = "Array" },
                    new Tag { Name = "Matrix" },
                    new Tag { Name = "Hashing" },
                    new Tag { Name = "Stack" },
                    new Tag { Name = "Queue" },
                    new Tag { Name = "Heap" },
                    new Tag { Name = "Graph" },
                    new Tag { Name = "Linked List" },
                    new Tag { Name = "Binary Search" },
                    new Tag { Name = "Two Pointer" },
                    new Tag { Name = "Sliding Window" },
                    new Tag { Name = "Divide and Conquer" },
                    new Tag { Name = "Breadth First Search" },
                    new Tag { Name = "Depth First Search" },
                    new Tag { Name = "Topological Sort" },
                    new Tag { Name = "Trie" },
                    ];
                await context.Set<Tag>().AddRangeAsync(tags, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        });

    }
}

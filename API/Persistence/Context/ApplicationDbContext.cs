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
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var testBlog = await context.Set<User>().FirstOrDefaultAsync();
            if (testBlog == null)
            {
                context.Set<User>().Add(new User {Username="bishal", Password= "$2a$12$ts.Zth9ExVhCADk8BSUDleKjduJGkziBy9w4XhG7Ptm8/iuIcp2iG", Role="Admin"});
                await context.SaveChangesAsync(cancellationToken);
            }
        });

    }
}

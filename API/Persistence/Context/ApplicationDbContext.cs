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
                context.Set<User>().Add(new User { Username = "bishal", Password = "$2a$12$ts.Zth9ExVhCADk8BSUDleKjduJGkziBy9w4XhG7Ptm8/iuIcp2iG", Role = "Admin" });
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

            var semester = context.Set<Semester>().FirstOrDefault();
            if (semester == null)
            {
                List<Semester> semesters = [];

                Semesters.Add(new Semester
                {
                    Title = "I",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC109", Title = "Introduction to Information Technology", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC110", Title = "C Programming", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSCI11", Title = "Digital Logic", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "MTHI112", Title = "Mathematics I", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "PHY113", Title = "Physics", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "II",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC160", Title = "Discrete Structure", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSCI61", Title = "Object Oriented Programming", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSCI62", Title = "Microprocessor", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "MTH163", Title = "Mathematics II", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "STA164", Title = "Statistics I", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "III",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC206", Title = "Data Structure and Algorithms", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC207", Title = "Numerical Method", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC208", Title = "Computer Architecture", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC209", Title = "Computer Graphics", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "STA210", Title = "Statistics II", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "IV",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC257", Title = "Theory of Computation", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC258", Title = "Computer Networks", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC259", Title = "Operating Systems", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC260", Title = "Database Management System", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC261", Title = "Artificial Intelligence", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "V",
                    TotalCreditHour = 18,
                    TotalFullMark = 600,
                    Courses =
                    [
                        new Course { Code = "CSC314", Title = "Design and Analysis of Algorithms", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC315", Title = "System Analysis and Design", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC316", Title = "Cryptography", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC317", Title = "Simulation and Modeling", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC318", Title = "Web Technology", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC319", Title = "Multimedia Computing", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC320", Title = "Wireless Networking", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC321", Title = "Image Processing", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC322", Title = "Knowledge Management", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC323", Title = "Society and Ethics in Information Technology", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC324", Title = "Microprocessor Based Design", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "VI",
                    TotalCreditHour = 18,
                    TotalFullMark = 600,
                    Courses =
                    [
                        new Course { Code = "CSC364", Title = "Software Engineering", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC365", Title = "Compiler Design and Construction", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC366", Title = "E-Governance", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC367", Title = "NET Centric Computing", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC368", Title = "Technical Writing", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC369", Title = "Applied Logic", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC370", Title = "E-commerce", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC371", Title = "Automation and Robotics", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC372", Title = "Neural Networks", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC373", Title = "Computer Hardware Design", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC374", Title = "Cognitive Science", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "VII",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC409", Title = "Advanced Java Programming", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC410", Title = "Data Warehousing and Data Mining", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "MGT411", Title = "Principles of Management", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC412", Title = "Project Work", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "Elective III", Title = "Elective Course", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC413", Title = "Information Retrieval", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC414", Title = "Database Administration", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC415", Title = "Software Project Management", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC416", Title = "Network Security", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC417", Title = "Digital System Design", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "MGT418", Title = "International Marketing", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "VIII",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses = 
                    [
                        new Course { Code = "CSC461", Title = "Advanced Database", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC462", Title = "Internship", CreditHours = 0, FullMarks = 200 },
                        new Course { Code = "CSC463", Title = "Advanced Networking with IPV6", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC464", Title = "Distributed Networking", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC465", Title = "Game Technology", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC466", Title = "Distributed and Object Oriented Database", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC467", Title = "Introduction to Cloud Computing", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC468", Title = "Geographical Information System", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC469", Title = "Decision Support System and Expert System", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC470", Title = "Mobile Application Development", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC471", Title = "Real Time Systems", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC472", Title = "Network and System Administration", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC473", Title = "Embedded Systems Programming", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "MGT474", Title = "International Business Management", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });

                context.Set<Semester>().AddRange(semesters);
                context.SaveChanges();
            }
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var testBlog = await context.Set<User>().FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (testBlog == null)
            {
                await context.Set<User>().AddAsync(new User { Username = "bishal", Password = "$2a$12$ts.Zth9ExVhCADk8BSUDleKjduJGkziBy9w4XhG7Ptm8/iuIcp2iG", Role = "Admin" }, cancellationToken);
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

            var semester = await context.Set<Semester>().FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (semester == null)
            {
                List<Semester> semesters = [];

                Semesters.Add(new Semester
                {
                    Title = "I",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC109", Title = "Introduction to Information Technology", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC110", Title = "C Programming", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSCI11", Title = "Digital Logic", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "MTHI112", Title = "Mathematics I", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "PHY113", Title = "Physics", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "II",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC160", Title = "Discrete Structure", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSCI61", Title = "Object Oriented Programming", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSCI62", Title = "Microprocessor", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "MTH163", Title = "Mathematics II", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "STA164", Title = "Statistics I", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "III",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC206", Title = "Data Structure and Algorithms", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC207", Title = "Numerical Method", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC208", Title = "Computer Architecture", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC209", Title = "Computer Graphics", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "STA210", Title = "Statistics II", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "IV",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC257", Title = "Theory of Computation", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC258", Title = "Computer Networks", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC259", Title = "Operating Systems", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC260", Title = "Database Management System", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC261", Title = "Artificial Intelligence", CreditHours = 3, FullMarks = 100 }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "V",
                    TotalCreditHour = 18,
                    TotalFullMark = 600,
                    Courses =
                    [
                        new Course { Code = "CSC314", Title = "Design and Analysis of Algorithms", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC315", Title = "System Analysis and Design", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC316", Title = "Cryptography", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC317", Title = "Simulation and Modeling", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC318", Title = "Web Technology", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC319", Title = "Multimedia Computing", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC320", Title = "Wireless Networking", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC321", Title = "Image Processing", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC322", Title = "Knowledge Management", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC323", Title = "Society and Ethics in Information Technology", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC324", Title = "Microprocessor Based Design", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "VI",
                    TotalCreditHour = 18,
                    TotalFullMark = 600,
                    Courses =
                    [
                        new Course { Code = "CSC364", Title = "Software Engineering", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC365", Title = "Compiler Design and Construction", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC366", Title = "E-Governance", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC367", Title = "NET Centric Computing", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC368", Title = "Technical Writing", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC369", Title = "Applied Logic", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC370", Title = "E-commerce", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC371", Title = "Automation and Robotics", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC372", Title = "Neural Networks", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC373", Title = "Computer Hardware Design", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC374", Title = "Cognitive Science", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "VII",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC409", Title = "Advanced Java Programming", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC410", Title = "Data Warehousing and Data Mining", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "MGT411", Title = "Principles of Management", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC412", Title = "Project Work", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "Elective III", Title = "Elective Course", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC413", Title = "Information Retrieval", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC414", Title = "Database Administration", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC415", Title = "Software Project Management", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC416", Title = "Network Security", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC417", Title = "Digital System Design", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "MGT418", Title = "International Marketing", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });
                Semesters.Add(new Semester
                {
                    Title = "VIII",
                    TotalCreditHour = 15,
                    TotalFullMark = 500,
                    Courses =
                    [
                        new Course { Code = "CSC461", Title = "Advanced Database", CreditHours = 3, FullMarks = 100 },
                        new Course { Code = "CSC462", Title = "Internship", CreditHours = 0, FullMarks = 200 },
                        new Course { Code = "CSC463", Title = "Advanced Networking with IPV6", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC464", Title = "Distributed Networking", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC465", Title = "Game Technology", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC466", Title = "Distributed and Object Oriented Database", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC467", Title = "Introduction to Cloud Computing", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC468", Title = "Geographical Information System", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC469", Title = "Decision Support System and Expert System", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC470", Title = "Mobile Application Development", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC471", Title = "Real Time Systems", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC472", Title = "Network and System Administration", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "CSC473", Title = "Embedded Systems Programming", CreditHours = 3, FullMarks = 100, IsElective = true },
                        new Course { Code = "MGT474", Title = "International Business Management", CreditHours = 3, FullMarks = 100, IsElective = true }
                    ]
                });

                await context.Set<Semester>().AddRangeAsync(semesters, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        });

    }
}

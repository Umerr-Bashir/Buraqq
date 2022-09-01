using Microsoft.EntityFrameworkCore;

namespace Buraqq.Models
{
    public class BuraqqContext:DbContext
    {
        public BuraqqContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Global turn off delete behaviour foreign keys
            foreach (var Relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                Relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CourseStatus> CourseStatuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

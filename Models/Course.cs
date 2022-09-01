namespace Buraqq.Models
{
    public class Course
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int Fee { get; set; }
        public virtual User Teacher { get; set; }
        public int TeacherId { get; set; }
        public User Student { get; set; }
        public int StudentId { get; set; }
        public virtual CourseStatus CourseStatus { get; set; }
        public int RequestStatusId { get; set; }
    }
}

namespace Buraqq.Models
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public virtual User Teacher { get; set; }
        public int TeacherId { get; set; }
        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}

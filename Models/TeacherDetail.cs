namespace Buraqq.Models
{
    public class TeacherDetail
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Fee { get; set; }
        public virtual User Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}

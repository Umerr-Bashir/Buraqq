namespace Buraqq.Models.ViewModel
{
    public class TeacherInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<string> Subject { get; set; }= new List<string>();
        public int Fee { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}

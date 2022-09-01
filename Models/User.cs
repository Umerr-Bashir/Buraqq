namespace Buraqq.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String AccessToken { get; set; }
        public int Phone { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}

namespace Buraqq.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public virtual User Sender { get; set; }
        public int SenderId { get; set; }
        public virtual User Receiver { get; set; }
        public int ReceiverId { get; set; }
        public virtual Course Course { get; set; }
        public int YourRequestId { get; set; }
    }
}

using System;

namespace MessagesCRUD.Domain
{
    public class Message
    {
        public string UserId { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }
    }
}

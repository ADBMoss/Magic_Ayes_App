using System;

namespace Magic_Ayes.Models
{
    public class Ticket
    {
        public long TicketID { get; set; }
        public string Subject { get; set; }
        public string TDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Engineer { get; set; }
        public string Owner { get; set; }
        public long ProjectID { get; set; }
        public bool IsAssigned { get; set; }
        public string TicketStatus { get; set; }
        public string TicketPriority { get; set; }
        public string IssueType { get; set; }
        public string TicketComment { get; set; } //Also put in TicketDetails Section
    }
}

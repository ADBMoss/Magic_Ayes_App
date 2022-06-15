using Magic_Ayes.Models;
using System.Collections.Generic;

namespace Magic_Ayes
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAllTickets();
        public Ticket GetTicket(long ticketID);
        public void UpdateTicket(Ticket ticket);
        public void CreateTicket(Ticket ticketToCreate);
        //public IEnumerable<IssueType> GetAllIssueTypes();
        public Ticket AssignIssueType();
        //public IEnumerable<TicketPriority> GetAllTicketPriorities();
        public Ticket AssignTicketPriority();
        //public IEnumerable<TicketStatus> GetAllTicketStatuses();
        public Ticket AssignTicketStatus();
        public bool IsTicketAssigned(long ticketID);
        public Ticket GetCurrentDate();
        public Ticket GetLastUpdatedDate();
        public void AssignTicketTo(long ticketID);
        public void DeleteTicket(Ticket ticket);
    }
}

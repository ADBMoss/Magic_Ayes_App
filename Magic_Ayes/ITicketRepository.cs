using Magic_Ayes.Models;
using System.Collections.Generic;

namespace Magic_Ayes
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAllTickets();
        public Ticket GetTicket(int ticketID);
        public void UpdateTicket(Ticket ticket);
        public void CreateTicket(Ticket ticketToCreate);
        //public IEnumerable<IssueType> GetAllIssueTypes();
        public Ticket AssignIssueType();
        //public IEnumerable<TicketPriority> GetAllTicketPriorities();
        public Ticket AssignTicketPriority();
        //public IEnumerable<TicketStatus> GetAllTicketStatuses();
        public Ticket AssignTicketStatus();
        public bool IsTicketAssigned(int ticketID);
        public Ticket GetCurrentDate();
        public Ticket GetLastUpdatedDate();
        public void AssignTicketTo(int ticketID);
        public void DeleteTicket(Ticket ticket);
    }
}

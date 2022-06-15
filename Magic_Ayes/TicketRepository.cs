using Dapper;
using Magic_Ayes.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Magic_Ayes
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDbConnection _conn;

        public TicketRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //Getting All
        //public IEnumerable<TicketStatus> GetAllTicketStatuses()
        //{
        //    return _conn.Query<TicketStatus>("SELECT * FROM TICKETSTATUSES");
        //}

        //public IEnumerable<IssueType> GetAllIssueTypes()
        //{
        //    return _conn.Query<IssueType>("SELECT * FROM ISSUETYPES");
        //}
        //public IEnumerable<TicketPriority> GetAllTicketPriorities()
        //{
        //    return _conn.Query<TicketPriority>("SELECT * FROM TICKETPRIORITIES");
        //}

        //public IEnumerable<Ticket> GetAllAssignedTickets()
        //{
        //    return _conn.Query<Ticket>("SELECT * FROM TICKETS WHERE isAssigned = 1");
        //}

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _conn.Query<Ticket>("SELECT * FROM TICKETS");
        }

        //Getting Single
        public Ticket GetTicket(int id)
        {
            return _conn.QuerySingle<Ticket>("SELECT * FROM TICKETS WHERE @id", new { TicketID = id });
        }

        //Update
        public void UpdateTicket(Ticket ticket)
        {
            _conn.Execute("UPDATE tickets SET Subject = @subject, Description = @description, Owner = @owner, Engineer = @engineer, TicketStatus = @ticketStatus, " +
                          "TicketPriority = @ticketPriority, IssueType = @issueType, TicketComment = @comment WHERE TicketID = @id",
                          new
                          {
                              subject = ticket.Subject,
                              description = ticket.TDescription,
                              owner = ticket.Owner,
                              engineer = ticket.Engineer,
                              ticketStatus = ticket.TicketStatus,
                              ticketPriority = ticket.TicketPriority,
                              issueType = ticket.IssueType,
                              ticketComment = ticket.TicketComment
                          });
        }

        public void CreateTicket(Ticket ticketToCreate)
        {
            _conn.Execute("INSERT INTO tickets (SUBJECT, TDESCRIPTION, CREATIONDATE, LASTUPDATED, ENGINEER, OWNER, PROJECTID, ISASSIGNED, TICKETSTATUS, TICKETPRIORITY, ISSUETYPE, TICKETCOMMENT) " +
                          "VALUES (@subject, @description, @creationDate, @lastUpdated, @engineer, @owner, @projectID, @isAssigned, @ticketStatus, @ticketPriority, @issueType, @ticketComment);",
                          new
                          {
                              subject = ticketToCreate.Subject,
                              description = ticketToCreate.TDescription,
                              creationDate = ticketToCreate.CreationDate,
                              lastUpdated = ticketToCreate.LastUpdated,
                              engineer = ticketToCreate.Engineer,
                              owner = ticketToCreate.Owner,
                              projectID = ticketToCreate.ProjectID,
                              isAssigned = ticketToCreate.IsAssigned,
                              ticketStatus = ticketToCreate.TicketStatus,
                              ticketPriority = ticketToCreate.TicketPriority,
                              issueType = ticketToCreate.IssueType,
                              ticketComment = ticketToCreate.TicketComment
                          });
        }

        public void DeleteTicket(Ticket ticket)
        {
            _conn.Execute("DELETE FROM DASHBOARD WHERE TicketID = @id;", new { id = ticket.TicketID });
            _conn.Execute("DELETE FROM Project WHERE TicketID = @id;", new { id = ticket.TicketID });
        }

        //public Ticket AssignIssueType()
        //{
        //    var issueTypeList = GetAllIssueTypes();
        //    var ticket = new Ticket();
        //    ticket.IssueType = issueTypeList;
        //    return ticket;
        //}

        //public Ticket AssignTicketPriority()
        //{
        //    var ticketPriorityList = GetAllTicketPriorities();
        //    var ticket = new Ticket();
        //    ticket.TicketPriority = ticketPriorityList;
        //    return ticket;
        //}

        public Ticket AssignTicketStatus()
        {
            var ticket = new Ticket();
            ticket.TicketStatus = "Finished";
            return ticket;
        }


        //public bool IsTicketAssigned(long ticketID)
        //{
        //    var allAssigned = GetAllAssignedTickets();
        //    var theAnswer = _conn.QuerySingle<Ticket>("SELECT * FROM TICKETS WHERE ISASSIGNED = @ticketID & 1");

        //    if (theAnswer == allAssigned)
        //    {
        //        return true;
        //    }
        //    return false;
        //}



        //public void AssignTicketTo(long thisID)
        //{
        //    throw new NotImplementedException();
        //}




        public Ticket GetCurrentDate()
        {
            var dateTime = new DateTime();
            var ticket = new Ticket();
            ticket.CreationDate = dateTime.Date;
            return ticket;
        }

        public Ticket GetLastUpdatedDate()
        {
            throw new NotImplementedException();
        }

        public Ticket AssignIssueType()
        {
            throw new NotImplementedException();
        }

        public Ticket AssignTicketPriority()
        {
            throw new NotImplementedException();
        }

        

        public bool IsTicketAssigned(int ticketID)
        {
            throw new NotImplementedException();
        }

        public void AssignTicketTo(int ticketID)
        {
            throw new NotImplementedException();
        }
    }
}

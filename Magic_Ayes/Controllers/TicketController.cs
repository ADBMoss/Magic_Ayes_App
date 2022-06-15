using Magic_Ayes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magic_Ayes.Controllers
{
    public class TicketController : Controller
    {

        private readonly ITicketRepository _repo;

        public TicketController(ITicketRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var tickets = _repo.GetAllTickets();
            return View(tickets);
        }

        public IActionResult ViewTicket(int id)
        {
            var ticket = _repo.GetTicket(id);
            return View(ticket);
        }

        public IActionResult UpdateTicket(int id)
        {
            Ticket tick = _repo.GetTicket(id);

            if (tick == null)
            {
                return View("TicketNotFound");
            }

            return View(tick);
        }

        public IActionResult UpdateTicketToDatabase(Ticket ticket)
        {
            _repo.UpdateTicket(ticket);
            return RedirectToAction("ViewTicket", new { id = ticket.TicketID });
        }

        //public IActionResult CreateTicket()
        //{
        //    var tick = _repo.AssignTicketStatus();
        //    return View(tick);
        //}

        //public IActionResult CreateTicket2()
        //{
        //    var tick = _repo.AssignTicketPriority();
        //    return View(tick);
        //}

        //public IActionResult CreateTicket3()
        //{
        //    var tick = _repo.AssignTicketPriority();
        //    return View(tick);
        //}

        public IActionResult InsertTicketToDatabase(Ticket ticketToCreate)
        {
            _repo.CreateTicket(ticketToCreate);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTicket(Ticket ticket)
        {
            _repo.DeleteTicket(ticket);
            return RedirectToAction("Index");
        }


        
    }
}

using EventuresApp.Data;
using EventuresApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace EventuresApp.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;
        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var events = context.Events
                .Include(e => e.Owner)
                .Select(e => new EventAllViewModel
                {
                    Name = e.Name,
                    Place = e.Place,
                    Start = e.Start.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    End = e.End.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner = e.Owner.UserName,

                    PricePerTicket = e.PricePerTicket,
                    TotalTickets = e.TotalTickets
                })
                .ToList();

            return View(events);
        }

        //Създавам страница Create Get Create HTTpPOS
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                Event eventForDb = new Event
                {
                    Name = bindingModel.Name,
                    Place = bindingModel.Place,
                    Start = bindingModel.Start,
                    End = bindingModel.End,
                    TotalTickets = bindingModel.TotalTickets,
                    PricePerTicket = bindingModel.PricePerTicket,
                    OwnerId = currentUserId,
                   
                };

                context.Events.Add(eventForDb);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }

            return this.View();
        }

    }
}

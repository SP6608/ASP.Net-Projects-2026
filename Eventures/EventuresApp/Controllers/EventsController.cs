using EventuresApp.Data;
using EventuresApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            List<EventAllViewModel>events=context.Events.
                Select(e=>new EventAllViewModel()
                {
                    Name = e.Name,
                    Place=e.Place,
                    Start=e.Start.ToString("dd-MM-yyyy HH:mm",CultureInfo.InvariantCulture),
                    End=e.End.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    Owner=e.Owner.UserName
                }).ToList();
            return View(events);
        }
    }
}

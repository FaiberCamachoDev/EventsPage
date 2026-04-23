using Microsoft.AspNetCore.Mvc;
using EventsPage.Models;
namespace EventsPage.Controllers
{
    public class EventsController : Controller
    {
        // Simulación de base de datos (temporal)
        private static List<Event> events = new List<Event>();
        private static int nextId = 1;

        // READ (Lista)
        public IActionResult Index()
        {
            return View(events);
        }

        // CREATE (GET) este recibe la vista de create
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST) este recibe los datos
        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            newEvent.Id = nextId++;
            events.Add(newEvent);

            return RedirectToAction("Index");
        }
        // ver los details del evento
        public IActionResult Details(int id)
        {
            var ev = events.FirstOrDefault(e => e.Id == id);

            if (ev == null)
                return NotFound();

            return View(ev);
        }
        // mandar a vista de edicion
        public IActionResult Edit(int id)
        {
            var ev = events.FirstOrDefault(e => e.Id == id);

            if (ev == null)
                return NotFound();

            return View(ev);
        }
        // guardar cambios del evento editado
        [HttpPost]
        public IActionResult Edit(Event updatedEvent)
        {
            var ev = events.FirstOrDefault(e => e.Id == updatedEvent.Id);

            if (ev == null)
                return NotFound();

            ev.Title = updatedEvent.Title;
            ev.Description = updatedEvent.Description;
            ev.Date = updatedEvent.Date;
            ev.Location = updatedEvent.Location;
            ev.ImageUrl = updatedEvent.ImageUrl;

            return RedirectToAction("Index");
        }
        // eliminar evento
        // GET  mostrar confirmación vista
        public IActionResult Delete(int id)
        {
            var ev = events.FirstOrDefault(e => e.Id == id);

            if (ev == null)
                return NotFound();

            return View(ev);
        }

// POST eliminar
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var ev = events.FirstOrDefault(e => e.Id == id);

            if (ev != null)
            {
                events.Remove(ev);
            }

            return RedirectToAction("Index");
        }
    }
}
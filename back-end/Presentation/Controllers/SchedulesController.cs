using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataDomain;
using DataPersistence;

namespace Presentation.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly DataBaseContext _context;

        public SchedulesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schedules.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!_context.Schedules.Any(t => t.Id == id))
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .SingleOrDefaultAsync(m => m.Id == id);

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Medic,Patient,Diagnosis")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.Id = Guid.NewGuid();
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!_context.Schedules.Any(t => t.Id == id))
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.SingleOrDefaultAsync(m => m.Id == id);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Date")] Schedule schedule)
        {
            if (!_context.Schedules.Any(t => t.Id == id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              _context.Update(schedule);
              await _context.SaveChangesAsync();

              return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!_context.Schedules.Any(t => t.Id == id))
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .SingleOrDefaultAsync(m => m.Id == id);

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var schedule = await _context.Schedules.SingleOrDefaultAsync(m => m.Id == id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

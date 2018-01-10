using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataDomain;
using DataPersistence;

namespace Presentation.Controllers
{
    public class MedicsController : Controller
    {
        private readonly DataBaseContext _context;

        public MedicsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Medics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medics.ToListAsync());
        }

        // GET: Medics/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medic = await _context.Medics
                .SingleOrDefaultAsync(m => m.Id == id);
            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // GET: Medics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Specialization,Rating,Id,FirsName,LastName,Username,Password,Gender,Role")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                medic.Id = Guid.NewGuid();
                _context.Add(medic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medic);
        }

        // GET: Medics/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medic = await _context.Medics.SingleOrDefaultAsync(m => m.Id == id);
            if (medic == null)
            {
                return NotFound();
            }
            return View(medic);
        }

        // POST: Medics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Category,Specialization,Rating,Id,FirsName,LastName,Username,Password,Gender,Role")] Medic medic)
        {
            if (id != medic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicExists(medic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medic);
        }

        // GET: Medics/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medic = await _context.Medics
                .SingleOrDefaultAsync(m => m.Id == id);
            if (medic == null)
            {
                return NotFound();
            }

            return View(medic);
        }

        // POST: Medics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medic = await _context.Medics.SingleOrDefaultAsync(m => m.Id == id);
            _context.Medics.Remove(medic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicExists(Guid id)
        {
            return _context.Medics.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataDomain;
using DataPersistence;
using Microsoft.AspNetCore.Http;
using Presentation.Models;
using Utils;

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
            if (HttpContext.Session.GetString("user_name") != null && HttpContext.Session.GetString("user_name") != "")
            {
                return View(await _context.Medics.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Persons");
            }
        }

        // GET: Medics/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (!_context.Medics.Any(t => t.Id == id))
            {
                return NotFound();
            }

            var medic = await _context.Medics
                .SingleOrDefaultAsync(m => m.Id == id);

            return View(medic);
        }

        // GET: Medics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Specialization,Rating,Cnp,FirstName,EmailAddress,LastName,Username,Password,Gender,Birthday,Role")] Medic medic)
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
            if (!_context.Medics.Any(t => t.Id == id))
            {
                return NotFound();
            }

            var medic = await _context.Medics.SingleOrDefaultAsync(m => m.Id == id);
            return View(medic);
        }

        // POST: Medics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Category,Specialization,Rating,Cnp,FirstName,EmailAddress,LastName,Username,Password,Gender,Birthday,Role")] Medic medic)
        {
            if(!_context.Medics.Any(t => t.Id == id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(medic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medic);
        }

        // GET: Medics/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!_context.Medics.Any(t => t.Id == id))
            {
                return NotFound();
            }

            var medic = await _context.Medics
                .SingleOrDefaultAsync(m => m.Id == id);

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

        public IActionResult SendEmail()
        {
            return View();
        }

        // POST: People/SendEmail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(EmailSenderViewModel emailSenderVm)
        {
            if (!ModelState.IsValid) return View(emailSenderVm);
            var isOk = await _context.Persons
                .SingleOrDefaultAsync(m => m.Username == emailSenderVm.ToUsername);
            if (isOk == null) return View(emailSenderVm);
            MailUtils email;
            email = new MailUtils(isOk.EmailAddress, emailSenderVm.Subject,
                emailSenderVm.Body);

            email.Send();
            return RedirectToAction("Index", "Persons");
        }
    }
}

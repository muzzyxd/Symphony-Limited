using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<IActionResult> ShowContact()
        {
            var contact = await _context.Contacts.ToListAsync();
            return View(contact);
        }


        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _context.Contacts.AddAsync(contact);
                _context.SaveChanges();
                return RedirectToAction("ShowContact");
            }
            return View(contact);
        }

        public async Task<IActionResult> EditContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> EditContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowContact");
            }
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ShowContact");
        }
    }
}

using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using WebApiContact.Data;
using WebApiContact.Models;

namespace WebApiContact.Controllers
{
    public class ContactController : Controller
    {
        private AplicationContactDbContext _context;

        public ContactController(AplicationContactDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ContactModel> contact = _context.Contact;
            return View(contact);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactModel contact)
        {
            if (ModelState.IsValid && contact.SecondPhone == null)
            {
                contact.SecondPhone = "None";
                _context.Contact.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid) 
            {
                _context.Contact.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public IActionResult Edit(int? id)
        {
            var contact = _context.Contact.Find(id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Update(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var contact = _context.Contact.Find(id);

            if (contact == null) 
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int id) 
        {
            var contact = _context.Contact.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using HomeWork11.Data;
using HomeWork11.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork11.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationNoteDbContext _context;

        public NoteController(ApplicationNoteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<NoteModel> note = _context.Note;
            return View(note);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoteModel note)
        {
            if (ModelState.IsValid)
            {
                _context.Note.Add(note);
                _context.SaveChanges();
                TempData["ResultOK"] = "Created successfully";
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var note = _context.Note.Find(id);

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NoteModel note)
        {
            if (ModelState.IsValid)
            {
                _context.Note.Update(note);
                _context.SaveChanges();
                TempData["ResultOK"] = "Updated successfully";
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var note = _context.Note.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNote(int? id)
        {
            var note = _context.Note.Find(id);

            if (id == null)
            {
                return NotFound();
            }

            _context.Note.Remove(note);
            _context.SaveChanges();
            TempData["ResultOK"] = "Delete successfully";
            return RedirectToAction("Index");
        }
    }
}

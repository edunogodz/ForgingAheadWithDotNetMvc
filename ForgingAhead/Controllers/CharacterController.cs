using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using ForgingAhead.Models;

namespace ForgingAhead.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Characters";
            var model = _context.Characters.ToList();
            return View(model);
        }

        public IActionResult GetActive()
        {
            var model = _context.Characters.Where(e => e.IsActive).ToList();
            return View(model);
        }

        [Route("Character/{name}/Details")]
        public IActionResult Details(string name)
        {
            ViewData["Title"] = name;

            var model = _context.Characters.FirstOrDefault(e => e.Name == name);
            return View(model);
        }

        [Route("Character/{name}/Edit")]
        public IActionResult Edit(string name)
        {
            ViewData["Title"] = "Edit " + name;

            var model = _context.Characters.FirstOrDefault(e => e.Name == name);
            return View(model);
        }

        public IActionResult Update(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete
        [Route("Character/{name}/Delete")]
        public IActionResult Delete(string name)
        {
            var character = _context.Characters.FirstOrDefault(e => e.Name == name);
            _context.Characters.Remove(character);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
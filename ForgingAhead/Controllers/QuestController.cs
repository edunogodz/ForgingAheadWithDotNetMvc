using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using ForgingAhead.Models;

namespace ForgingAhead.Controllers
{
  public class QuestController : Controller
  {
    private readonly ApplicationDbContext _context;

    public QuestController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Quest quest)
    {
      _context.Quests.Add(quest);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
      var model = _context.Quests.ToList(); 
      return View(model);
    }
    public IActionResult Details(string name)
    {
      var model = _context.Quests.FirstOrDefault(e => e.Name == name);
      return View(model);
    }

    public IActionResult Update(Quest quest)
    {
       _context.Entry(quest).State = EntityState.Modified;
       _context.SaveChanges();      
      return RedirectToAction("Index");
    }

    public IActionResult Delete(string name)
    {
      var original = _context.Quests.FirstOrDefault(e => e.Name == name);
            if (original != null)
            {
                _context.Quests.Remove(original);
                _context.SaveChanges();
            
            }
      
      return RedirectToAction("Index");
    }







  }
}
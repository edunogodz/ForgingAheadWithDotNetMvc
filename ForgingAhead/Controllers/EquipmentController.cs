using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using ForgingAhead.Models;

namespace ForgingAhead.Controllers
{
  public class EquipmentController : Controller
  {
    private readonly ApplicationDbContext _context;

    public EquipmentController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Equipment equipment)
    {
      _context.Equipment.Add(equipment);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
      return View();
    }
  }
}
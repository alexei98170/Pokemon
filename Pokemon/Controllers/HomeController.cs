using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Data;
using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Pokemons.ToList());
        }
        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PokemonId = id;
            return View();
        }
        [HttpPost]
        public string Order(Order order)
        {
            db.Orders.Add(order);
          
            db.SaveChanges();
            return "Спасибо, " + order.Name + ", за покупку!";
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Data;
using Pokemon.Models;
using SocialApp.Services;
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
        public async Task<IActionResult> Order(Order order)
        {
            Order orderVew = order;
            orderVew.OrderDate = DateTime.Now;
            db.Orders.Add(orderVew);
          
            db.SaveChanges();
            return View("List");
        }
            public async Task<IActionResult> SendMessage()
            {
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync("somemail@mail.ru", "Заказ покемона", "Вы заказали покемона. Ожидайте звонка курьера. Хорошего дня! :)");
                return RedirectToAction("Index");
            }
        }
    }

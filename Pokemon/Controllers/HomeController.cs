using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Pokemon.Data;
using Pokemon.Models;
using Pokemon.ViewModels;
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
        private readonly ApplicationDbContext db;
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
        [ActionName("Order")]
        public ActionResult Order(Order order)
        {
            order.OrderDate = DateTime.Now;

            db.Orders.Add(order);
            db.SaveChanges();
            var count = db.Orders.Where(x => x.Email == order.Email).Count();
            var viewModel = new OrderViewModel(order, count);

            return View("List", viewModel);
        }

        public async Task<IActionResult> SendMessage()
        {
            EmailService emailService = new EmailService();
            await emailService.SendEmailAsync("somemail@mail.ru", "Заказ покемона", "Вы заказали покемона. Ожидайте звонка курьера. Хорошего дня! :)");

            return RedirectToAction("Index");
        }
    }
}

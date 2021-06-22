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
            return RedirectToAction("Order");
        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Order")]
        public async Task<IActionResult> Order(Order order)
        {
            order.OrderDate = DateTime.Now;

            db.Orders.Add(order);
            db.SaveChanges();
            var count = db.Orders.Where(x => x.Email == order.Email).Count();
            var viewModel = new OrderViewModel(order, count);
            var emailService = new EmailService();
            await emailService.SendEmailAsync(order.Email,"Заказ покемона", "Вы успешно заказали пакемона");
            return View("List", viewModel);
        }

     
    }
}

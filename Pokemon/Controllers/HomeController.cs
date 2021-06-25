using Microsoft.AspNetCore.Mvc;
using Pokemon.Data;
using Pokemon.Models;
using Pokemon.ViewModels;
using SocialApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
       
        public HomeController(
    
            ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Order");
        }

        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Order")]
        public async Task<IActionResult> Order(Order order)
        {
            order.OrderDate = DateTime.Now;

            var orderModel = db.Orders.ToList();

            var isExistsUserName = db.Orders.Any(x => x.Name == order.Name);

            if (!orderModel.Any(x => x.Email == order.Email && !db.Orders.Any(x => x.Name == order.Name)))
            {
                db.Orders.Add(order);
                db.SaveChanges();

               // var orderM = db.Orders.ToList();

                var orders = db.Orders.ToList();
                var uniqueOrders = orders.GroupBy(x => x.Email).Select(g => g.First()).AsEnumerable();
                var viewModels = uniqueOrders.Select(x => new OrderViewModel(x, orders.Where(o => o.Email == x.Email).Count()));
                var emailService = new EmailService();

                await emailService.SendEmailAsync(order.Email, "Заказ покемона", "Вы успешно заказали пакемона");

                return View("List", viewModels);
            }
            else return View("ErrorsMessageOrder");
        }
        public IActionResult Privacy()
        {
            return View();
        } 
    }
}

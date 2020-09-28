using BanckOfClothesServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace BanckOfClothesServer.Controllers
{
    public class HomeController : Controller
    {
        public static List<OrderDetails> ListOrderDetails = new List<OrderDetails>();
        List<SelectListItem> Products = new List<SelectListItem>();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateOrder()
        {
            var ApplicationDbContext = new ApplicationDbContext();
            var pros = ApplicationDbContext.Products.ToList();
            foreach (var item in pros)
            {
                Products.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewData["products"] = Products;
            return View();
        }
        public ActionResult MyOrder()
        {
            var ApplicationDbContext = new ApplicationDbContext();
            var id = User.Identity.GetUserId();
            var orders = ApplicationDbContext.Orders.Where(x => x.ApplicationUserId == id).ToList();
            return View("MyOrder", orders);
        }
        public void Add(List<OrderDetails> OrderDetails)
        {
            var ApplicationDbContext = new ApplicationDbContext();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId()).Id;
            var order = ApplicationDbContext.Orders.Add(new Order { ApplicationUserId = currentUser });
            ApplicationDbContext.SaveChanges();
            foreach (var item in OrderDetails)
            {
                item.OrderId = order.Id;
                ApplicationDbContext.OrderDetails.Add(item);
            }
            ApplicationDbContext.SaveChanges();
        }
        [HttpGet]
        [Route("GetOrderDetails/{id}")]
        public string GetOrderDetails(long id)
        {
            var ApplicationDbContext = new ApplicationDbContext();
            var result = ApplicationDbContext.OrderDetails.Where(x => x.OrderId == id).ToList();
            var json = JsonConvert.SerializeObject(result);
            return json;
        }
    }
}
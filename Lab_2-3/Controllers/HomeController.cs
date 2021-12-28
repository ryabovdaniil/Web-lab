using Farmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Farmacy.Controllers
{
    public class HomeController : Controller
    {

        ItemContext db = new ItemContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты 
            IEnumerable<Item> items = db.Items;
            ViewBag.Items = items;
            return View();
        }

        public ActionResult Item(int id)
        {

            Item item = db.Items.Find(id);
            ViewBag.ThisItem = item;
            return View();

        }


        public ActionResult ToBasket(int id)
        {
            Basket basket = new Basket();
            basket.ItemId = id;
            db.Baskets.Add(basket);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Basket(int Total = 0)
        {
            IEnumerable<Basket> baskets = db.Baskets;
            List<Item> Items = new List<Item>();
            foreach (var Bas in baskets)
            {
                foreach (var item in db.Items)
                {
                    if (Bas.ItemId == item.Id)
                    {
                        Items.Add(item);
                        Total += item.Price;
                    }
                }
            }
            ViewBag.Total = Total;

            ViewBag.ThisBasket = Items;
            return View();
        }


        [HttpPost]
        public ActionResult ItemSearch(string name)
        {
            var allitems = db.Items.Where(a => a.Name.Contains(name)).ToList();
            if (allitems.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allitems);
        }

       

        public ActionResult Buy()
        {
            IEnumerable<Basket> basket = db.Baskets;
            List<Item> items = new List<Item>();
            foreach (var BS in basket)
            {
                foreach (var item in db.Items)
                {
                    if (BS.ItemId == item.Id)
                    {
                        items.Add(item);
                        db.Baskets.Remove(BS);
                        break;
                    }
                }
            }
            foreach (var i in items)
            {
                Order order = new Order();
                order.ItemId = i.Id;
                db.Orders.Add(order);
            }
            db.SaveChanges();
            return View();
        }
    }
}
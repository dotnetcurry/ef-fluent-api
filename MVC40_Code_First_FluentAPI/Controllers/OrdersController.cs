using MVC40_Code_First_FluentAPI.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC40_Code_First_FluentAPI.Controllers
{
    public class OrdersController : Controller
    {
        SalesContext objContext;

        public OrdersController()
        {
            objContext = new SalesContext(); 
        }

        //
        // GET: /Orders/

        public ActionResult Index()
        {
            var Orders = objContext.Orders.ToList();
            return View(Orders);
        }

        public ActionResult Create()
        {
            var Order = new Order();
            return View(Order);
        }
        [HttpPost]
        public ActionResult Create(Order ord)
        {
            objContext.Orders.Add(ord);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var Order = objContext.Orders.Where(o=>o.OrderId==id).First();
            return View(Order);
        }

        [HttpPost]
        public ActionResult Delete(int id,Order ord)
        {
            var Order = objContext.Orders.Where(o => o.OrderId == id).First();
            if (Order != null)
            {
                objContext.Orders.Remove(Order);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

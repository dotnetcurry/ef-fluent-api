using MVC40_Code_First_FluentAPI.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC40_Code_First_FluentAPI.Controllers
{
    public class CustomersController : Controller
    {
        SalesContext objContext;

        public CustomersController()
        {
            objContext = new SalesContext(); 
        }

        
        //
        // GET: /Customers/

        public ActionResult Index()
        {
            var Customers = objContext.Customers.ToList();
            return View(Customers);
        }

        public ActionResult Create()
        {
            var Customer = new Customer();
            return View(Customer);
        }

        [HttpPost]
        public ActionResult Create(Customer Cust)
        {
            objContext.Customers.Add(Cust);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var Cust = objContext.Customers.Where(c => c.CustomerId==id).First();
            return View(Cust);
        }

        [HttpPost]
        public ActionResult Delete(int id,Customer Cust)
        {
            var Customer = objContext.Customers.Where(c => c.CustomerId == id).First();
            if (Customer != null)
            {
                objContext.Customers.Remove(Customer);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

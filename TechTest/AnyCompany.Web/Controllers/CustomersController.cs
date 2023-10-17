using AnyCompany.Entities;
using AnyCompany.Services;
using System.Web.Mvc;

namespace AnyCompany.Web.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {            
            return View(CustomerService.GetAllCustomers());
        }

        public ActionResult Details(int id)
        {
            var customer = CustomerService.GetCustomerById(id);

            var orders = OrderService.GetOrdersForCustomer(customer.CustomerId);

            customer.Orders = orders;

            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                int result = CustomerService.AddCustomer(customer);

                if (result == 0)
                {
                    return View(customer);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View(customer);
        }
    }
}
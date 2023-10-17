using AnyCompany.Entities;
using AnyCompany.Services;
using System;
using System.Web.Mvc;

namespace AnyCompany.Web.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Create()
        {
            var customerId = Request.QueryString["customerId"];

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                var order = new Order { CustomerId = Convert.ToInt32(customerId) };
                return View(order);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order, int customerId)
        {
            if (ModelState.IsValid)
            {
                bool result = OrderService.PlaceOrder(order, customerId);

                if (result)
                {
                    return RedirectToAction("Details", "Customers", new { id = customerId });
                }
            }

            return View(order);
        }
    }
}
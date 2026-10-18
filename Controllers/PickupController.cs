using Microsoft.AspNetCore.Mvc;

public class PickupController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string orderId)
    {
        if (string.IsNullOrEmpty(orderId))
        {
            ViewBag.ErrorMessage = "Please enter a valid Order ID.";
            return View();
        }
          var order = Repository.GetMealOrders().FirstOrDefault(o => o.OrderID == orderId);

        if (order == null)
        {
            ViewBag.ErrorMessage = "Order with ID '" + orderId + "' was not found.";
            return View();
        }
        order.Collected = true;
        order.CollectedAt = DateTime.Now;

        return RedirectToAction("Info", "Order", new { id = order.OrderID });
    }


}
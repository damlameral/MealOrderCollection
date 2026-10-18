using Microsoft.AspNetCore.Mvc;
public class OrderController : Controller
{
    public IActionResult Index()
    {
        
        var allOrders = Repository.GetMealOrders();

        ViewBag.TotalOrdersCount = allOrders.Count;

        return View(allOrders);
    }
public IActionResult Info(string id)
{
    if (string.IsNullOrEmpty(id))
    {
        return RedirectToAction("Index");
    }

    var selectedOrder = Repository.GetMealOrders().FirstOrDefault(o => o.OrderID == id);

    if (selectedOrder == null)
    {
        return NotFound();
    }

    return View(selectedOrder);
}

}
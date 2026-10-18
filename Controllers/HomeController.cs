using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.CafeteriaName = "Sakarya University Cafeteria";
        ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy");
        var deliveredMeals = Repository.GetMealOrders().Where(item => item.Collected).ToList();
        ViewBag.DeliveredCount = deliveredMeals.Count;

        return View(deliveredMeals);
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Bemerkto.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Products";
        return View();
    }


    public IActionResult Details(int id)
    {
        ViewData["Title"] = "Product info";
        return View(id);
    }
}

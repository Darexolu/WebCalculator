using createWebApplicationCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace createWebApplicationCalculator.Controllers
{
    public class CalculatorController: Controller
    {
        public IActionResult CalculatorView() { 
             return View(new CalculatorModel());
        }
    }
}

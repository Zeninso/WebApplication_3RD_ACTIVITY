using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpensesDbContext _context;

        public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses= _context.Expenses.ToList();
            return View(allExpenses);
        }

        public IActionResult CreateEditExpense()
        {
            return View();
        }

        public IActionResult CreateEditExpenseForm(Expenses model) 
        {
            _context.Expenses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

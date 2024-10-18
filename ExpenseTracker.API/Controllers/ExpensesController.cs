using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Library.Models; // Adjust namespace as needed
using System.Collections.Generic;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        // Example data for demonstration
        private static List<Expense> expenses = new List<Expense>
        {
            new Expense { Id = 1, Description = "Lunch", Amount = 15.00M },
            new Expense { Id = 2, Description = "Transport", Amount = 2.50M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses()
        {
            return Ok(expenses);
        }

        // Additional methods (POST, PUT, DELETE) can be added later.
    }
}

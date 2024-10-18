using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Library.Models; // Adjust namespace as needed
using System.Collections.Generic;
using System.Linq;

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

        // GET: api/expenses
        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses()
        {
            return Ok(expenses);
        }

        // GET: api/expenses/{id}
        [HttpGet("{id}")]
        public ActionResult<Expense> GetExpenseById(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        // POST: api/expenses
        [HttpPost]
        public ActionResult<Expense> CreateExpense([FromBody] Expense newExpense)
        {
            newExpense.Id = expenses.Count > 0 ? expenses.Max(e => e.Id) + 1 : 1; // Simple ID assignment
            expenses.Add(newExpense);
            return CreatedAtAction(nameof(GetExpenseById), new { id = newExpense.Id }, newExpense);
        }

        // PUT: api/expenses/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateExpense(int id, [FromBody] Expense updatedExpense)
        {
            var existingExpense = expenses.FirstOrDefault(e => e.Id == id);
            if (existingExpense == null)
            {
                return NotFound();
            }

            existingExpense.Description = updatedExpense.Description;
            existingExpense.Amount = updatedExpense.Amount;
            return NoContent();
        }

        // DELETE: api/expenses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            expenses.Remove(expense);
            return NoContent();
        }
    }
}

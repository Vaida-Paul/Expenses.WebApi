using Expenses.Core;
using Expenses.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private IExpensesServices _expenseServices;
        public ExpensesController(IExpensesServices expenseServices)
        {
            _expenseServices = expenseServices;
        }
        [HttpGet]
        public IActionResult GetExpenses()
        {
            return Ok(_expenseServices.GetExpenses());
        }
        [HttpGet("{id}", Name = "GetExpense")]
        public IActionResult GetExpense(int id)
        {
            return Ok(_expenseServices.GetExpense(id));
        }

        [HttpPost]
        public IActionResult CreateExpense(DB.Expense expenses)
        {
            var newExpense = _expenseServices.CreateExpense(expenses);
            return CreatedAtRoute("GetExpense", new { newExpense.Id }, newExpense);
        }
        [HttpDelete]
        public IActionResult DeleteExpense(Expense expense) 
        {
            _expenseServices.DeleteExpense(expense);
            return Ok();
        }
        [HttpPut]
        public IActionResult EditExpense (Expense expense) 
        {
            return Ok(_expenseServices.EditExpense(expense));
        }
    }
}

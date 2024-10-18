using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using ExpenseTracker.Library.Models; 
using System.Collections.Generic;

namespace ExpenseTracker.Tests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<ExpenseTracker.API.ExpenseTrackerStartup>> // Update to the new class name
    {
        private readonly HttpClient _client;

        public UnitTest1(WebApplicationFactory<ExpenseTracker.API.ExpenseTrackerStartup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetExpenses_ReturnsOkResponse()
        {
            // Act
            var response = await _client.GetAsync("/api/expenses");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        [Fact]
        public async Task GetExpenses_ReturnsExpectedExpenseList()
        {
            // Act
            var response = await _client.GetAsync("/api/expenses");

            // Assert
            response.EnsureSuccessStatusCode(); 

            // Deserialize the response content
            var expenses = await response.Content.ReadFromJsonAsync<List<Expense>>();

            // Check that the expenses list is not null and has expected items
            Assert.NotNull(expenses);
            Assert.NotEmpty(expenses); 
        }

        [Fact]
        public async Task AddExpense_ReturnsCreatedResponse()
        {
            // Arrange
            var newExpense = new Expense
            {
                Description = "Test Expense",
                Amount = 50.00m,
                Date = DateTime.Now,
                Category = "Food",
                PaymentMethod = "Cash"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/expenses", newExpense);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 201
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            // Deserialize the response content to verify the added expense
            var addedExpense = await response.Content.ReadFromJsonAsync<Expense>();

            // Validate that the added expense matches the created expense
            Assert.NotNull(addedExpense);
            Assert.Equal(newExpense.Description, addedExpense.Description);
            Assert.Equal(newExpense.Amount, addedExpense.Amount);
            Assert.Equal(newExpense.Category, addedExpense.Category);
            Assert.Equal(newExpense.PaymentMethod, addedExpense.PaymentMethod);
        }

        [Fact]
        public async Task GetExpenseById_ReturnsExpectedExpense()
        {
            // Act
            var response = await _client.GetAsync("/api/expenses/1"); // Adjust to a valid ID

            // Assert
            response.EnsureSuccessStatusCode(); // Ensure we got a success status code

            // Deserialize the response content
            var expense = await response.Content.ReadFromJsonAsync<Expense>();

            // Check that the expense is not null
            Assert.NotNull(expense);

            // Validate that the expense ID is as expected (adjust this as necessary)
            Assert.Equal(1, expense.Id);
        }
    }
}

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
    }
}

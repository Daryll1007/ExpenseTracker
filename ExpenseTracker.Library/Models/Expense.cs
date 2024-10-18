using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Library.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now; // Default to now

        // New properties
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Payment Method is required")]
        public string PaymentMethod { get; set; }

        // Method to display expense details
        public string GetExpenseDetails()
        {
            return $"ID: {Id}, Description: {Description}, Amount: {Amount:C}, Date: {Date.ToShortDateString()}, Category: {Category}, Payment Method: {PaymentMethod}";
        }
    }
}

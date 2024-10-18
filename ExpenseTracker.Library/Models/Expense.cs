namespace ExpenseTracker.Library.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; // Default to now
    }
}

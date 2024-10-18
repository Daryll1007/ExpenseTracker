namespace ExpenseTracker.Library.Models
{
    /// <summary>
    /// Represents a category for expenses in the Expense Tracker application.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the category.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date when the category was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            CreatedDate = DateTime.Now; // Sets the created date to now by default
        }

        /// <summary>
        /// Returns a string representation of the category.
        /// </summary>
        /// <returns>A string that represents the category.</returns>
        public override string ToString()
        {
            return $"{Name} (ID: {Id}) - Created on {CreatedDate.ToShortDateString()}";
        }
    }
}

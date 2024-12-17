namespace LibraryApplication.Models
{
    public class Book
    {
        public int BookId { get; set; } // Assuming there's an ID property
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int? PublicationYear { get; set; } // Use nullable int if it can be empty
    }
}

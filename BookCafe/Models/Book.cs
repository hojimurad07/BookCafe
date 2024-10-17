namespace BookCafe.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int ISBN {  get; set; }
        public string Title { get; set; } = string.Empty;
        public Genre Genre { get; set; } = Genre.None;
        public string Author {  get; set; } = string.Empty ;
        public int PageCount {  get; set; }
        public int Price { get; set; }
        public bool isAvailable {  get; set; } = false ;

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Price: ${Price}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Available: {(isAvailable ? "Yes" : "No")}");
            Console.WriteLine($"ISBN: {ISBN}");
        }
    }
}

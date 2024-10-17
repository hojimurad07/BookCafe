using System.Security.Cryptography;
using System.Xml.Linq;

namespace BookCafe.Models
{
    public  class Customer
    {
        public int Id { get; set; }
        public string FullName {get; set; } = string.Empty;
        public List<Book> OrderBooks { get; set; } = new List<Book>();

        public void DisplayCustomerInfo()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Customer Name: {FullName}");
            Console.WriteLine($"Customer ID: {Id}");
            Console.WriteLine($"Ordered Books:");
            foreach (var book in OrderBooks)
            {
                Console.WriteLine($"- {book.Title}");
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}

using BookCafe.Interfaces;
using BookCafe.Models;
using System.Text.Json;

namespace BookCafe.Repository
{
    public class BookRepository : IBookInterface
    {
        private const string FilePath = "books.json";
        private List<Book> _books;

        public BookRepository()
        {
            _books = LoadBooksFromFile();
        }
        public void CreateBook(Book book)
        {
            _books.Add(book);
            SaveBooksToFile();
        }

        public void DeleteBook(int Id)
        {
            var book =  _books.Find(x => x.Id == Id);
            if (book != null)
            {
                _books.Remove(book);
                SaveBooksToFile();
            }


        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBook(int Id)
        {
            var book = _books.Find(z=>z.Id == Id);
            if(book != null)
            {
                return book;
            }
            else
            {
                throw new Exception("Bunday kitob mavjud emas");
            }
        }

        public void Update(Book book)
        {
            var index = _books.FindIndex(x=> x.Id == book.Id);  
            if (index != -1)
            {
                _books[index] = book;
                SaveBooksToFile() ;
            }
            else
            {
                throw new Exception("Bunday kitob mavjud emas");
            }
        }

        private void SaveBooksToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsondata = JsonSerializer.Serialize(_books, options);
            File.WriteAllText(FilePath, jsondata);
        }
        private List<Book> LoadBooksFromFile()
        {
            if(File.Exists(FilePath))
            {
                string jsondata = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize <List<Book>>(jsondata) ?? new List<Book>();
            }
            return new List<Book>();
        }
    }
}

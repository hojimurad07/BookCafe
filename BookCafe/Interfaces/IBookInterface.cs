using BookCafe.Models;

namespace BookCafe.Interfaces
{
    public  interface IBookInterface
    {
        void CreateBook(Book book);
        void DeleteBook(int Id);
        List<Book> GetAllBooks();
        Book GetBook(int Id);
        void Update(Book book);
    }
}

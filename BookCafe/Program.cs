using BookCafe.Models;
using BookCafe.Repository;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {

        BookRepository bookRepository = new BookRepository();
        CustomerRepository customerRepository = new CustomerRepository();

        Console.WriteLine("=========================Dasturimizga xush kelibsiz===================");
        bool holat = true;

        while (holat)
        {
            Console.WriteLine("1. Mijozlar Ro'yxati");
            Console.WriteLine("2. Mijoz qo'shish");
            Console.WriteLine("3. Mijoz o'chirish");
            Console.WriteLine("4. Mijozni o'zgartirish");
            Console.WriteLine("5. Mijozni kitoblarini ko'rish");
            Console.WriteLine("6. Kitoblar ro'yxati");
            Console.WriteLine("7. Kitob qo'shish");
            Console.WriteLine("8. Kitobni o'chirish");
            Console.WriteLine("9. Kitobni o'zgartirish");
            Console.WriteLine("10. Dasturni tugatish");

            int t = int.Parse(Console.ReadLine());

            switch (t)
            {
                case 1: // Display customer list
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    break;

                case 2: // Add a customer
                    Customer newCustomer = new Customer();
                    Console.Write("Mijozning ismini kiriting: ");
                    newCustomer.FullName = Console.ReadLine();
                    newCustomer.Id = (customerRepository.GetAllCustomers().Count > 0) ? customerRepository.GetAllCustomers().Last().Id + 1 : 1;
                    customerRepository.Create(newCustomer);
                    Console.WriteLine("Mijoz muvaffaqiyatli qo'shildi!");
                    break;

                case 3: // Delete a customer
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }

                    Console.WriteLine("O'chirmoqchi bo'lgan mijozning Id raqamini kiriting: ");
                    int i = int.Parse(Console.ReadLine());
                    customerRepository.Delete(i);
                    Console.WriteLine("Muvaffaqiyatli o'chirildi");
                    break;

                case 4: // Update a customer
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    Console.WriteLine("O'zgartirmoqchi bo'lgan mijozning Idsini kiriting: ");
                    int updateId = int.Parse(Console.ReadLine());
                    var update_customer = customerRepository.GetById(updateId);
                    if (update_customer != null)
                    {
                        Console.Write("Yangi ismini kiriting (bo'sh qoldiring agar o'zgartirmoqchi bo'lmasangiz): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newName))
                        {
                            update_customer.FullName = newName;
                            customerRepository.Update(update_customer);
                            Console.WriteLine("Mijoz muvaffaqiyatli o'zgartirildi!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bunday Id bilan mijoz topilmadi.");
                    }
                    break;

                case 5: // Display books ordered by a customer
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    Console.WriteLine("Ko'rmoqchi bo'lgan mijozning Idsini kiriting: ");
                    int id = int.Parse(Console.ReadLine());
                    var user = customerRepository.GetById(id);
                    if (user != null)
                    {
                        if (user.OrderBooks.Count == 0)
                        {
                            Console.WriteLine("Bu mijozda kitoblar yo'q");
                        }
                        else
                        {
                            foreach (var kitob in user.OrderBooks)
                            {
                                kitob.DisplayInfo();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bunday Id bilan mijoz topilmadi.");
                    }
                    break;

                case 6: // Display list of books
                    Console.WriteLine("Kitoblar ro'yxati: ");
                    foreach (var kitob in bookRepository.GetAllBooks())
                    {
                        kitob.DisplayInfo();
                    }
                    break;

                case 7: // Add a new book
                    Book newBook = new Book();

                    Console.Write("Kitob nomini kiriting: ");
                    newBook.Title = Console.ReadLine();

                    Console.Write("Kitobning muallifini kiriting: ");
                    newBook.Author = Console.ReadLine();

                    Console.Write("ISBN raqamini kiriting: ");
                    newBook.ISBN = int.Parse(Console.ReadLine());

                    Console.Write("Kitob janrini kiriting (0 = None, 1 = Fiction, etc.): ");
                    newBook.Genre = (Genre)int.Parse(Console.ReadLine());

                    Console.Write("Kitob narxini kiriting: ");
                    newBook.Price = int.Parse(Console.ReadLine());

                    Console.Write("Kitobning sahifa sonini kiriting: ");
                    newBook.PageCount = int.Parse(Console.ReadLine());

                    Console.Write("Kitob mavjudmi? (true/false): ");
                    newBook.isAvailable = bool.Parse(Console.ReadLine());

                    Console.WriteLine("Kimga biriktirmoqchimiz: ");
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    Console.WriteLine("Biriktirmoqchi bo'lgan mijozning Idsini kiriting: ");
                    int raqam = int.Parse(Console.ReadLine());
                    var userman = customerRepository.GetById(raqam);
                    userman.OrderBooks.Add(newBook);
                    bookRepository.CreateBook(newBook);
                    Console.WriteLine("Kitob muvaffaqiyatli qo'shildi.");


                    break;

                case 8: // Delete a book
                    Console.WriteLine("O'chirmoqchi bo'lgan kitobning Id raqamini kiriting: ");
                    int bookId = int.Parse(Console.ReadLine());
                    bookRepository.DeleteBook(bookId);
                    Console.WriteLine("Kitob muvaffaqiyatli o'chirildi.");
                    break;

                case 9: // Update a book
                    Console.WriteLine("O'zgartirmoqchi bo'lgan kitobning Id raqamini kiriting: ");
                    int bookUpdateId = int.Parse(Console.ReadLine());
                    Book bookToUpdate = bookRepository.GetBook(bookUpdateId);
                    if (bookToUpdate != null)
                    {
                        Console.Write("Yangi kitob nomini kiriting (bo'sh qoldiring agar o'zgartirmoqchi bo'lmasangiz): ");
                        string newBookName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newBookName))
                        {
                            bookToUpdate.Title = newBookName;
                        }

                        // Add more fields to update here if necessary

                        bookRepository.Update(bookToUpdate);
                        Console.WriteLine("Kitob muvaffaqiyatli o'zgartirildi.");
                    }
                    else
                    {
                        Console.WriteLine("Bunday Id bilan kitob topilmadi.");
                    }
                    break;

                case 10: // Exit the application
                    holat = false;
                    Console.WriteLine("Dastur tugatildi.");
                    break;

                default:
                    Console.WriteLine("Noto'g'ri tanlov, iltimos, yana urinib ko'ring.");
                    break;
            }
        }
    }
}

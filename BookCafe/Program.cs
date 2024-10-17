

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
            Console.WriteLine("1.Mijozlar Ro'yxati");
            Console.WriteLine("2.Mijoz qo'shish");
            Console.WriteLine("3.Mijoz o'chirish");
            Console.WriteLine("4.Mijozni o'zgartirish");
            Console.WriteLine("5.Delite");

            int t = int.Parse(Console.ReadLine());

            switch(t)
            {
                
                case 1:
                    foreach(var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    break;
                case 2:
                    
                    Customer newCustomer = new Customer();
                    Console.Write("Mijozning ismini kiriting: ");
                    newCustomer.FullName = Console.ReadLine();
                    newCustomer.Id = (customerRepository.GetAllCustomers().Count > 0) ? customerRepository.GetAllCustomers().Last().Id + 1 : 1;
                    customerRepository.Create(newCustomer);
                    break;
                case 3:
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    
                    Console.WriteLine("O'chirmoqchi bo'lgan mijozning Id raqamini kiriting: ");
                    int i = int.Parse(Console.ReadLine());
                    customerRepository.Delete(i);
                    Console.WriteLine("Muvaffaqiyatli o'chirildi");
                    break;
                case 4:
                    foreach (var c in customerRepository.GetAllCustomers())
                    {
                        c.DisplayCustomerInfo();
                    }
                    Console.WriteLine("O'zgartirmoqchi bo'lgan mijozning idsini kiriting: ");
                    int updateId = int.Parse(Console.ReadLine());
                    var update_customer = customerRepository.GetById(updateId);
                    if (update_customer != null)
                    {
                        Console.Write("Yangi ismini kiriting (bo'sh qoldiring agar o'zgartirmoqchi bo'lmasangiz): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newName))
                        {
                            update_customer.FullName = newName;
                        }
                    }
                    customerRepository.Update(update_customer);

                           
                  
                    break;
                case 5:
                        Console.Clear();
                        break;
                default:
                    Console.WriteLine("Noto'g'ri tanlov, iltimos, yana urinib ko'ring.");
                    break;

            }

        }
    }
}
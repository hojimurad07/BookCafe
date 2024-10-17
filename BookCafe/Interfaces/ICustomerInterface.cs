using BookCafe.Models;

namespace BookCafe.Interfaces
{
    public  interface ICustomerInterface
    {
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        List<Customer> GetAllCustomers();
        Customer GetById(int id);

    }
}

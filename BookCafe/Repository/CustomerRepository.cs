using BookCafe.Interfaces;
using BookCafe.Models;
using System.Text.Json;

namespace BookCafe.Repository
{
    public class CustomerRepository : ICustomerInterface
    {
        public const string FilePath = "customers.json";
        private List<Customer> _customers;
        public CustomerRepository()
        {
            _customers = LoadAllCustomer();
        }
        public void Create(Customer customer)
        {
            _customers.Add(customer);
            SaveCustomerData();
        }

        public void Delete(int id)
        {
            var customer = _customers.Find(x => x.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                SaveCustomerData();
            }
            else
            {
                Console.WriteLine("Bunday foydalanuvchi topilmadi");

            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetById(int id)
        {
            var cus =_customers.FindIndex(x => x.Id == id);
            if(cus != -1)
            {
                return _customers[cus];
            }
            else
            {
                throw new Exception("Bunday foydalanivchi tizmda yo'q");
            }
        }

        public void Update(Customer customer)
        {
            var index = _customers.FindIndex(b=>b.Id == customer.Id);
            if(index != -1)
            {
                _customers[index] = customer;
                SaveCustomerData();
            }
        }

        private void SaveCustomerData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsondata = JsonSerializer.Serialize(_customers, options);
            File.WriteAllText(FilePath, jsondata);
        }
        private List<Customer> LoadAllCustomer()
        {
            if(File.Exists(FilePath))
            {
                string jsondata = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Customer>>(jsondata) ?? new List<Customer>();
            }
            return new List<Customer>();
        }
    }
}

using NadusTech.Dtos;
using NadusTech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadusTech.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task <CustomerDto> GetCustomerAsync(string name);
        Task<Customer> GetCustomerByIdAsync(int Id);
        void AddCustomer(Customer customer);
        void UpdateCustomers(Customer customer);
        Task DeleteCustomers(int id);
        Task<bool> SaveAllAsync();

    }
}

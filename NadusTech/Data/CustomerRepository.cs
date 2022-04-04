using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NadusTech.Dtos;
using NadusTech.Entities;
using NadusTech.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadusTech.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(DataContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public void AddCustomer(Customer customer)
        {
          _context.Customers.Add(customer);
        }

        public async Task DeleteCustomers(int id)
        {
            _context.Customers.Remove(await GetCustomerByIdAsync(id));
        }

        public async Task<CustomerDto> GetCustomerAsync(string name)
        {
            return await _context.Customers
                .Where(x => x.Name == name)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

  public async Task<Customer> GetCustomerByIdAsync(int Id)
        {
            return await _context.Customers
                .Where(x => x.Id == Id)
               .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            return await _context.Customers
                  .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                  .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

       

        public void UpdateCustomers(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}

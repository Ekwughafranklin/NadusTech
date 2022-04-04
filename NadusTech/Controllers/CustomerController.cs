using Microsoft.AspNetCore.Mvc;
using NadusTech.Dtos;
using NadusTech.Entities;
using NadusTech.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadusTech.Controllers
{

    public class CustomerController:BaseApiController
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
      => Ok(await _customerRepository.GetCustomersAsync());
      
        [HttpGet("{username}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(string username)
      => Ok(await _customerRepository.GetCustomerAsync(username));



          [HttpPost("Delete/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
           await _customerRepository.DeleteCustomers(id);
            await _customerRepository.SaveAllAsync();
            return Ok("Customer was deleted Successfully");
        }
          
        [HttpPost]
        public async Task<ActionResult<Customer>> AddorEditCustomer(Customer customer)
        {
            if(customer.Id>0)
                _customerRepository.UpdateCustomers(customer);
          else
                _customerRepository.AddCustomer(customer);
            await _customerRepository.SaveAllAsync();
            return Ok(customer);
        }



    }
}

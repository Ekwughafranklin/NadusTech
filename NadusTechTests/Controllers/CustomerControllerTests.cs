using Xunit;
using NadusTech.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NadusTech.Interfaces;
using System.Text.Json;
using NadusTech.Dtos;
using Microsoft.AspNetCore.Mvc;
using NadusTech.Entities;

namespace NadusTech.Controllers.Tests
{
    public class CustomerControllerTests
    {
      public readonly Mock<ICustomerRepository> _userMock = new();
       
     
       
        [Fact()]
        public async Task GetSingleCustomerTest()
        {
            var todo = "{\"name\": \"Muriel\",\"age\": 25, \"phone\": \"(875) 573-2795\",\"address\": \"Muir\"}";
            var nex = JsonSerializer.Deserialize<CustomerDto>(todo);
            _userMock.Setup(p => p.GetCustomerAsync("muriel")).Returns(Task.FromResult(nex));
            CustomerController uss = new(_userMock.Object);
            var res = await uss.GetCustomer("muriel");
            Assert.IsType<ActionResult<CustomerDto>>(res);
        }

        [Fact()]
        public async Task DeleteCustomerTestAsync()
        {
            var todo = "{\"name\": \"Muriel\",\"age\": 25, \"phone\": \"(875) 573-2795\",\"address\": \"Muir\"}";
            var nex = JsonSerializer.Deserialize<CustomerDto>(todo);
            _userMock.Setup(p => p.DeleteCustomers(1));
            CustomerController uss = new(_userMock.Object);
            var res = await uss.DeleteCustomer(1);
            _userMock.Verify();
      
        }

        [Fact()]
        public async Task AddorEditCustomerTestAsync()
        {
            var todo = "{\"name\": \"Frank\",\"age\": 25, \"phone\": \"(875) 531-5678\",  \"address\": \"Muir\"}";
            var nex = JsonSerializer.Deserialize<Customer>(todo);
            _userMock.Setup(p => p.AddCustomer(nex));
            CustomerController uss = new(_userMock.Object);
            var res = await uss.AddorEditCustomer(nex);
            Assert.IsType<ActionResult<Customer>>(res);
        }
    }
}
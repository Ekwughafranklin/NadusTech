using Microsoft.EntityFrameworkCore;
using NadusTech.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NadusTech.Data
{
    public class Seed
    {
        public static async Task SeedCustomers(DataContext context)
        {
            if (await context.Customers.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<Customer>>(userData);
            foreach (var user in users)
            {
                context.Customers.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}

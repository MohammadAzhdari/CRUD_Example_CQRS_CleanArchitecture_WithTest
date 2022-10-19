using Mc2.CrudTest.Core.Entities;
using Mc2.CrudTest.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmailExists(int id, string email)
        {
            return await _dbContext.Set<Customer>().AnyAsync(x => x.Email == email && x.Id != id);
        }

        public async Task<bool> UserExists(int id, string fn, string ln, DateTime dob)
        {
            return await _dbContext.Set<Customer>()
                .AnyAsync(x => x.Firstname == fn
                            && x.Lastname == ln
                            && x.DateOfBirth == dob
                            && x.Id != id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<bool> EmailExists(int id, string email);
        public Task<bool> UserExists(int id, string fn, string ln, DateTime dob);
    }
}

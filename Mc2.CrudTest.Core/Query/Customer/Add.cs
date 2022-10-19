using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Query.Customer
{
    public class Add : IRequest<Entities.Customer>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public Add(Entities.Customer entity)
        {
            this.Id = entity.Id;
            this.PhoneNumber = entity.PhoneNumber;
            this.Email = entity.Email;
            this.BankAccountNumber = entity.BankAccountNumber;
            this.DateOfBirth = entity.DateOfBirth;
            this.Firstname = entity.Firstname;
            this.Lastname = entity.Lastname;
        }
    }
}

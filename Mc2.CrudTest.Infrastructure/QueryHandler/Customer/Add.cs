using Mc2.CrudTest.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.QueryHandler.Customer
{
    public class Add : IRequestHandler<Core.Query.Customer.Add, Core.Entities.Customer>
    {
        private readonly IRepository _repository;
        private readonly ICustomerRepository _customerRepository;

        public Add(
            IRepository repository,
            ICustomerRepository customerRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
        }

        public async Task<Core.Entities.Customer> Handle(Core.Query.Customer.Add request, CancellationToken cancellationToken)
        {
            Core.Entities.Customer result = null;

            // validate
            if (!await Validation(request)) 
                return result;

            // insert
            if (request.Id is 0)
                result = await Insert(request);
            // update
            else
                result = await Update(request);

            return result;
        }

        private async Task<Core.Entities.Customer> Insert(Core.Query.Customer.Add request)
        {
            var result = await _repository.AddAsync(new Core.Entities.Customer
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                DateOfBirth = request.DateOfBirth,
                BankAccountNumber = request.BankAccountNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            });
            return result;
        }

        private async Task<Core.Entities.Customer> Update(Core.Query.Customer.Add request)
        {
            Core.Entities.Customer result = null;
            var updated = await _repository.UpdateAsync(new Core.Entities.Customer
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                DateOfBirth = request.DateOfBirth,
                BankAccountNumber = request.BankAccountNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
            });
            if (updated)
                result = new Core.Entities.Customer
                {
                    Id = request.Id
                };

            return result;
        }

        public async Task<bool> Validation(Core.Query.Customer.Add request)
        {
            if (!IsValidPhoneNumber(request.PhoneNumber))
                return false;

            if (!IsValidBankAccount(request.BankAccountNumber))
                return false;

            if (!await IsValidEmail(request.Id, request.Email))
                return false;

            if (!await IsNewUser(request.Id, request.Firstname, request.Lastname, request.DateOfBirth))
                return false;

            return true;
        }

        private async Task<bool> IsValidEmail(int id, string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            if (!new EmailAddressAttribute().IsValid(email)) return false;

            if (await _customerRepository.EmailExists(id, email)) return false;

            return true;
        }

        private static bool IsValidPhoneNumber(string phone)
        {
            if (Regex.Match(phone, @"^(\+\d{1,3}[- ]?)?\d{10}$").Success)
                return true;
            else
                return false;
        }

        private static bool IsValidBankAccount(string account)
        {
            if (Regex.Match(account, "((\\d{4})-){3}\\d{4}").Success)
                return true;
            else
                return false;
        }

        private async Task<bool> IsNewUser(int id, string fn, string ln, DateTime dob)
        {
            if (await _customerRepository.UserExists(id, fn, ln, dob)) return false;

            return true;
        }
    }
}

using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.AddCustomerTest
{
    public class Validation
    {
        [Fact]
        public async Task ReturnSuccessAsync()
        {
            #region Arrange

            // declare mock
            var mockICustomerRepository = new Mock<Infrastructure.Interfaces.ICustomerRepository>();
            // setup email validate
            mockICustomerRepository
                .SetupSequence(x => x.EmailExists(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(false);
            // setup user validate
            mockICustomerRepository
                .SetupSequence(x => x.UserExists(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(false);
            // declare Add Customer Class
            var addCustomer = new Infrastructure.QueryHandler.Customer.Add(null, mockICustomerRepository.Object);

            #endregion

            #region Act

            var customer = new Core.Entities.Customer
            {
                BankAccountNumber = "1234-1234-1234-1234",
                DateOfBirth = DateTime.Today,
                Email = "info@gmail.com",
                Firstname = "Mohammad",
                Lastname = "Azhdari",
                PhoneNumber = "+989021192486"
            };
            var customerHandler = new Core.Query.Customer.Add(customer);

            #endregion

            #region Assert

            var result = await addCustomer.Validation(customerHandler);
            Assert.True(result);

            #endregion
        }

        [Theory]
        [InlineData("444ddd-dads-ddddd", "", "", "", false, false)] // invalid Bank Account
        [InlineData("1234-1234-1234-1234", "wrongEmail.com", "Mohammad", "+989021192486", false, false)] // invalid Email
        [InlineData("1234-1234-1234-1234", "info@Email.com", "NameExist", "+989021192486", false, true)] // name Exist
        [InlineData("1234-1234-1234-1234", "info@Email.com", "Mohammad", "+98902119248d", false, false)] // invalid Phone
        public async Task ReturnFailAsync(
            string bankAccount,
            string email,
            string firstname,
            string phoneNumber,
            bool emailExist,
            bool userExist)
        {
            #region Arrange

            // declare mock
            var mockICustomerRepository = new Mock<Infrastructure.Interfaces.ICustomerRepository>();
            // setup email validate
            mockICustomerRepository
                .SetupSequence(x => x.EmailExists(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(emailExist);
            // setup user validate
            mockICustomerRepository
                .SetupSequence(x => x.UserExists(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(userExist);
            // declare Add Customer Class
            var addCustomer = new Infrastructure.QueryHandler.Customer.Add(null, mockICustomerRepository.Object);

            #endregion

            #region Act

            var customer = new Core.Entities.Customer
            {
                BankAccountNumber = bankAccount,
                DateOfBirth = DateTime.Today,
                Email = email,
                Firstname = firstname,
                Lastname = "Azhdari",
                PhoneNumber = phoneNumber
            };
            var customerHandler = new Core.Query.Customer.Add(customer);

            #endregion

            #region Assert

            var result = await addCustomer.Validation(customerHandler);
            Assert.False(result);

            #endregion
        }
    }
}

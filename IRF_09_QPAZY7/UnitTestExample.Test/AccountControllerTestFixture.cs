using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using UnitTestExample.Abstractions;
using UnitTestExample.Controllers;
using UnitTestExample.Entities;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("nincsenszam",false),
            TestCase("NINCSKISBETU",false),
            TestCase("nincsnagybetu", false),
            TestCase("NINCSKISBETU", false),
            TestCase("r", false),
            TestCase("Abcd1234", true)
        ]
        public void TestValidationPswd(string pswd, bool expectedResult)
        {
            // Arrange
            var accountcontroller = new AccountController();

            // Act
            var actualResult = accountcontroller.ValidatePassword(pswd);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
            Test,
            TestCase("bence@bence.hu", "Abcd1234"),
            TestCase("szevasz@csao.hu", "Abcd1234"),
        ]   
        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            //var accountController = new AccountController();
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Returns<Account>(a => a);
            var accountController = new AccountController();
            accountController.AccountManager = accountServiceMock.Object;

            // Act
            var actualResult = accountController.Register(email, password);

            // Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
            accountServiceMock.Verify(m => m.CreateAccount(actualResult), Times.Once);
        }
     
         [
            Test,
            TestCase("bence@bence" , "Abcd1234"),
            TestCase("bence@bence.hu", "A"),
            TestCase("bence@bence", "A")
         ]
         public void TestRegisterValidateException(string email, string password)
         {
            // Arrange
            var accountController = new AccountController();

            //Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }
        }

    }
}

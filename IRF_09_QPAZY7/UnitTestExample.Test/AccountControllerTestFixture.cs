using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestExample.Controllers;

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
            TestCase("Ez1F*SzaJel5zo", true),
        ]
        public void TestValidationPswd(string pswd,string expectedResult)
        {
            // Arrange
            var accountcontroller = new AccountController();

            // Act
            var actualResult = accountcontroller.ValidatePassword(pswd);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }       
    }
}

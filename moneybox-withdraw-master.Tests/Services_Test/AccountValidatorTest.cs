using Moq;
using Xunit;
using System;
using Moneybox.App.DataAccess;
using Moneybox.App.Domain;
using Moneybox.App.Domain.Services;

namespace moneybox_withdraw_master.Tests.Services_Test
{

    public class AccountValidatorTest
    {

        /* BALANCE VALIDATION */
        
        [Fact]
        public void ErrorIfNegativeBalance()
        {
            var accountValidator = new AccountValidator();

            /* Make sure proper error is thrown for insufficient funds */
            Assert.Throws<InvalidOperationException>(() => accountValidator.ValidateBalance(-112m));
        }

        [Fact]
        public void PassIfProperBalance()
        {
            var accountValidator = new AccountValidator();

            var exception = Record.Exception(() => accountValidator.ValidateBalance(4000m));
            Assert.Null(exception);
        }

        /* PAYMENT VALIDATIONS */

        [Fact]
        public void ErrorIfReachedPayInLimit()
        {
            var accountValidator = new AccountValidator();

            /* See if proper exception is thrown with reched limit */
            Assert.Throws<InvalidOperationException>(() => accountValidator.ValidatePayment(decimal.Add(4000m, 4000m)));
        }

        [Fact]
        public void PassIfProperPayment()
        {
            var accountValidator = new AccountValidator();


            /* Make sure that no error is thrown if the balance is enough */
            var paymentException = Record.Exception(() => accountValidator.ValidatePayment(decimal.Subtract(4000m, 300m)));
            Assert.Null(paymentException);
        }

    }
}

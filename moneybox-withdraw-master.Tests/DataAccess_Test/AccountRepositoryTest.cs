using Moq;
using Xunit;
using Moneybox.App.Domain.Services;
using Moneybox.App.DataAccess;

namespace moneybox_withdraw_master.Tests.DataAccess_Test
{

    public class AccountRepositoryTest
    {

        [Fact]
        public void GetAccountById()
        {
            /* arrange */
            var accountRepository = new Mock<IAccountRepository>();

            var account = new Mock<IAccount>();
            var id = new System.Guid();
            account.SetupGet(u => u.Id).Returns(id);
            account.SetupGet(u => u.Balance).Returns(4000m);
            accountRepository.Setup(_ => _.GetAccountById(account.Object.Id)).Returns(account.Object);

            /* act */
            var accountFromRepo = accountRepository.Object.GetAccountById(id);

            /* assert */
            Assert.Equal(id, accountFromRepo.Id);

        }

    }
}

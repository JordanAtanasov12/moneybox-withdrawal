using System;
using Moq;
using Xunit;
using System.Net.Mail;
using Moneybox.App.Domain.Services;
using Moneybox.App.DataAccess;


namespace moneybox_withdraw_master.Tests.ServicesTests
{

    public class NotificationHandlerTest
    {
        [Fact]
        public void SendLowFundsNotification()
        {
            /* arrange */
            var notificationHandler = new Mock<INotificationHandler>();
            var user = new Mock<IUser>();
            user.SetupGet(u => u.Email).Returns("test@test.test");

            /* assert */
            var lowFundsError = Record.Exception(() => notificationHandler.Object.HandleLowFunds(decimal.Subtract(500m, 10m), user.Object));
            Assert.Null(lowFundsError);
        }

        [Fact]
        public void NotifyForApprochingLimits()
        {
            /* arrange */
            var notificationHandler = new Mock<INotificationHandler>();
            
            var user = new Mock<IUser>();
            user.SetupGet(u => u.Email).Returns("test@test.test");

            /* assert */
            var approchingLimitError = Record.Exception(() => notificationHandler.Object.HandleApproachingPayInLimit(decimal.Subtract(500m, 10m), user.Object));
            Assert.Null(approchingLimitError);
        }

    }
}

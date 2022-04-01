using Moq;
using Xunit;
using System.Net.Mail;
using Moneybox.App.Domain.Services;
using Moneybox.App.DataAccess;

namespace moneybox_withdraw_master.Tests.Services_Test
{

    public class NotificationHandlerTest
    {
        [Fact]
        public void SendLowFundsNotification()
        {
            var notificationHandler = new Mock<INotificationHandler>();
            var user = new Mock<IUser>();
            user.SetupGet(u => u.Email).Returns("test@test.test");

            /*
                Asuming that the Notification Service sends email,
                Check that mail for low funds is being properly sent, and no error
                is thrown
            */
            Assert.Throws<SmtpException>(() => notificationHandler.Object.HandleLowFunds(decimal.Subtract(500m, 10m), user.Object));
        }

        [Fact]
        public void NotifyForApprochingLimits()
        {
            var notificationHandler = new Mock<INotificationHandler>();
             var user = new Mock<IUser>();
            user.SetupGet(u => u.Email).Returns("test@test.test");

            /*
                Asuming that the Notification Service sends email,
                Check user is being properly notified for approching Pay Limit
            */
            Assert.Throws<SmtpException>(() => notificationHandler.Object.HandleApproachingPayInLimit(decimal.Subtract(500m, 10m), user.Object));
        }

    }
}

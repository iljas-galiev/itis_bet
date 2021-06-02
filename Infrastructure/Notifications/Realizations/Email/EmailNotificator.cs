using DAL.Models;
using Infrastructure.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmailNotifications
{
    class EmailNotificator : EmailNotificatorBase, INotificator<bool>
    {
        protected readonly Dictionary<NotificationReson, Func<string, Task<bool>>> _notifyAboutRegistration;
        protected readonly Dictionary<NotificationReson, Func<string, Task<bool>>> _notifyAboutSecurity;
        protected readonly Dictionary<NotificationReson, Func<string, UsersBets, Task<bool>>> _notifyAboutBet;
        protected readonly Dictionary<NotificationReson, Func<string, Transactions, Task<bool>>> _notifyAboutTransaction;


        public EmailNotificator(EmailSender sender) : base(sender) {

            _notifyAboutRegistration = new Dictionary<NotificationReson, Func<string, Task<bool>>> {
                { NotificationReson.RegistrationSucceeded, base.AboutRegistrationSucceeded}
            };

            _notifyAboutBet = new Dictionary<NotificationReson, Func<string, UsersBets, Task<bool>>> {
                { NotificationReson.BetApplyed, base.AboutBetApplyed },
                { NotificationReson.BetLoosed, base.AboutBetLoosed},
                { NotificationReson.BetApplyed, base.AboutBetApplyed }
            };

            _notifyAboutSecurity = new Dictionary<NotificationReson, Func<string, Task<bool>>>
            {
                { NotificationReson.PassportUpdated, base.AboutPassportUpdated},
                { NotificationReson.ProfileUpdated, base.AboutProfileUpdated}
            };

            _notifyAboutTransaction = new Dictionary<NotificationReson, Func<string, Transactions, Task<bool>>>
            {
                { NotificationReson.TransactionPassed, base.AboutTransactionPassed }
            };

        }


        public async Task<bool> About(NotificationReson reson)
        {
            throw new NotImplementedException();
        }
    }
}

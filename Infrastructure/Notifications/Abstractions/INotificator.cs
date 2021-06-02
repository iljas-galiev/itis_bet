using System.Threading.Tasks;

namespace Infrastructure.Notifications
{
    public enum NotificationReson
    {
        RegistrationSucceeded,

        PassportUpdated,
        ProfileUpdated,

        BetApplyed,
        BetWinned,
        BetLoosed,
        
        TransactionPassed
    }

    public interface INotificator<TResult>
    {
        public Task<TResult> About(NotificationReson reson);
    }
}

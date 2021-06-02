using DAL.Models;
using System.Threading.Tasks;

namespace Infrastructure.Notifications
{
    public enum RegistrationReason
    {
        Succeeded,
    }

    public enum SecurityReason
    {
        PassportUpdated,
        ProfileUpdated,
    }

    public enum BetReason
    {
        Applyed,
        Winned,
        Loosed,
    }

    public enum TransactionReason
    {
        Passed
    }

    public interface INotificator<TResult>
    {
        public Task<TResult> AboutRegistration(RegistrationReason reson, string email);

        public Task<TResult> AboutSecurity(SecurityReason reson, string email);

        public Task<TResult> AboutBet(BetReason reson, string email, UsersBets bet);

        public Task<TResult> AboutTransaction(TransactionReason reson, string email, Transactions transaction);

    }
}

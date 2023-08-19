using MoneyAdministratorBackend.Models;

namespace MoneyAdministratorBackend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CreditCardSummary> CreditCardResumeRepository { get; }
        IRepository<CreditCardSummaryDetail> CreditCardResumeDetailRepository { get; }
        IRepository<CreditCard> CreditCardRepository { get; }
        IRepository<CreditCardBrand> CreditCardTypeRepository { get; }
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<CurrencyValue> CurrencyValueRepository { get; }
        IRepository<Entity> EntityRepository { get; }
        IRepository<EntityType> EntityTypeRepository { get; }
        IRepository<Salary> SalaryRepository { get; }
        IRepository<Transaction> TransactionRepository { get; }
        IRepository<TransactionDetail> TransactionDetailRepository { get; }

        void Save();
    }
}

using MoneyAdministratorBackend.Interfaces;
using MoneyAdministratorBackend.Models;

namespace MoneyAdministratorBackend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IRepository<CreditCardSummary>? _creditCardResumeRepository;
        private IRepository<CreditCardSummaryDetail>? _creditCardResumeDetailRepository;
        private IRepository<CreditCard>? _creditCardRepository;
        private IRepository<CreditCardBrand>? _creditCardTypeRepository;
        private IRepository<Currency>? _currencyRepository;
        private IRepository<CurrencyValue>? _currencyValueRepository;
        private IRepository<Entity>? _entityRepository;
        private IRepository<EntityType>? _entityTypeRepository;
        private IRepository<Salary>? _salaryRepository;
        private IRepository<TransactionDetail>? _transactionDetailRepository;
        private IRepository<Transaction>? _transactionRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<CreditCardSummary> CreditCardResumeRepository =>
            _creditCardResumeRepository ??= new Repository<CreditCardSummary>(_context);

        public IRepository<CreditCardSummaryDetail> CreditCardResumeDetailRepository =>
            _creditCardResumeDetailRepository ??= new Repository<CreditCardSummaryDetail>(_context);

        public IRepository<CreditCard> CreditCardRepository =>
            _creditCardRepository ??= new Repository<CreditCard>(_context);

        public IRepository<CreditCardBrand> CreditCardTypeRepository =>
            _creditCardTypeRepository ??= new Repository<CreditCardBrand>(_context);

        public IRepository<Currency> CurrencyRepository =>
            _currencyRepository ??= new Repository<Currency>(_context);

        public IRepository<CurrencyValue> CurrencyValueRepository =>
            _currencyValueRepository ??= new Repository<CurrencyValue>(_context);

        public IRepository<Entity> EntityRepository =>
            _entityRepository ??= new Repository<Entity>(_context);

        public IRepository<EntityType> EntityTypeRepository =>
            _entityTypeRepository ??= new Repository<EntityType>(_context);

        public IRepository<Salary> SalaryRepository =>
            _salaryRepository ??= new Repository<Salary>(_context);

        public IRepository<TransactionDetail> TransactionDetailRepository =>
            _transactionDetailRepository ??= new Repository<TransactionDetail>(_context);

        public IRepository<Transaction> TransactionRepository =>
            _transactionRepository ??= new Repository<Transaction>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

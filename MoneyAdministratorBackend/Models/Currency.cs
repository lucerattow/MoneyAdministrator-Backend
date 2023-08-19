using System.ComponentModel.DataAnnotations;

namespace MoneyAdministratorBackend.Models
{
    public class Currency
    {
        //Properties
        public int Id { get; set; }

        public string Name { get; set; }

        //foreign keys all constraints
        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<CurrencyValue> CurrencyValues { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}

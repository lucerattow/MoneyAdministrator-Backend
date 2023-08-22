using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace MoneyAdministratorBackend.Models
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }

        //foreign keys all constraints
        public IEnumerable<CreditCard> CreditCards { get; set; }

        public IEnumerable<CurrencyValue> CurrencyValues { get; set; }

        public IEnumerable<Entity> Entities { get; set; }

        public IEnumerable<EntityType> EntityTypes { get; set; }

        public IEnumerable<Salary> Salaries { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}

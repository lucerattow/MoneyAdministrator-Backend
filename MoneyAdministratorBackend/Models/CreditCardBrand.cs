using System.ComponentModel.DataAnnotations;

namespace MoneyAdministratorBackend.Models
{
    public class CreditCardBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //foreign keys all constraints
        public IEnumerable<CreditCard> CreditCards { get; set; }
    }
}

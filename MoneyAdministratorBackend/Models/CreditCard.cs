using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoneyAdministratorBackend.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int EntityId { get; set; }

        public int CreditCardBrandId { get; set; }

        public string LastFourNumbers { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //foreign keys
        public User User { get; set; }

        public Entity Entity { get; set; }

        public CreditCardBrand CreditCardBrand { get; set; }

        //foreign keys all constraints
        public IEnumerable<CreditCardSummary> CreditCardSumaries { get; set; }
    }
}

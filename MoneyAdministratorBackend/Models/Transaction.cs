using MoneyAdministratorBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyAdministratorBackend.Models
{
    public class Transaction
    {
        //Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "Falta especificar el usuario")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Falta especificar el tipo de entidad")]
        public int EntityId { get; set; }

        [Required(ErrorMessage = "Falta especificar la moneda")]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Falta especificar el tipo de transacción")]
        public TransactionType TransactionType { get; set; }

        [StringLength(150, ErrorMessage = "La descripción no puede superar los 150 caracteres")]
        public string Description { get; set; }

        //foraign keys
        public User User { get; set; }

        public Entity Entity { get; set; }

        public Currency Currency { get; set; }

        //foreign keys all constraints
        public ICollection<TransactionDetail> TransactionDetails { get; set; }

        public ICollection<CreditCardSummary> CreditCardSummaries { get; set; }
    }
}

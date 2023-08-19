using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoneyAdministratorBackend.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyAdministratorBackend.Models
{
    public class CreditCardSummaryDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Falta especificar el resumen")]
        public int CreditCardSummaryId { get; set; }

        [Required(ErrorMessage = "Falta especificar el tipo de detalle")]
        public CreditCardSummaryDetailType Type { get; set; }

        [Required(ErrorMessage = "Falta ingresar la fecha del detalle")]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Installments { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountArs { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountUsd { get; set; }

        //foreign keys
        public CreditCardSummary CreditCardSummary { get; set; }
    }
}

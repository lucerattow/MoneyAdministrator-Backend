using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyAdministratorBackend.Models
{
    public class CreditCardSummary
    {
        public int Id { get; set; }

        public int CreditCardId { get; set; }

        public int TransactionId { get; set; }

        [DefaultValue(0)]
        public int TransactionPayId { get; set; }

        public DateTime Period { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateExpiration { get; set; }

        public DateTime DateNext { get; set; }

        public DateTime DateNextExpiration { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalArs { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalUsd { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MinimumPayment { get; set; }

        [DefaultValue(false)]
        public bool Imported { get; set; }

        //foreign keys
        public Transaction Transaction { get; set; }

        public CreditCard CreditCard { get; set; }

        //foreign keys all constraints
        public IEnumerable<CreditCardSummaryDetail> CreditCardSummaryDetails { get; set; }
    }
}

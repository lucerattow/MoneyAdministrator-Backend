using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyAdministratorBackend.Models
{
    public class TransactionDetail
    {
        //Columnas
        public int Id { get; set; }

        public int TransactionId { get; set; }

        public DateTime Date { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public int Frequency { get; set; }

        [DefaultValue(true)]
        public bool Concider { get; set; }

        [DefaultValue(false)]
        public bool Paid { get; set; }

        //foreign keys
        public Transaction Transaction { get; set; }
    }
}

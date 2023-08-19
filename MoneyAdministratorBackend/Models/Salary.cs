using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyAdministratorBackend.Models
{
    public class Salary
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public int CurrencyId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        //foraign keys
        public User User { get; set; }

        public Currency Currency { get; set; }
    }
}

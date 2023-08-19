using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoneyAdministratorBackend.Models
{
    public class Entity
    {
        //Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "Falta especificar el usuario")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Falta especificar el tipo de entidad")]
        public int EntityTypeId { get; set; }

        [StringLength(25, MinimumLength = 3, ErrorMessage = "El nombre de la entidad debe tener entre 3 y 25 caracteres")]
        [Required(ErrorMessage = "Falta indicar el nombre de la entidad")]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //foreign keys
        public User User { get; set; }

        public EntityType EntityType { get; set; }

        //foreign keys all constraints
        public ICollection<Transaction> Transactions { get; set; }
    }
}

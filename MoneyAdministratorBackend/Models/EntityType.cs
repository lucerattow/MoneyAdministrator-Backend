using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoneyAdministratorBackend.Models
{
    public class EntityType
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //foraign keys
        public User User { get; set; }

        //foreign keys all constraints
        public IEnumerable<Entity> Entities { get; set; }
    }
}

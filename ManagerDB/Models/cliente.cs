using System.ComponentModel.DataAnnotations;

namespace ManagerDB.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
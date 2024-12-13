using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarshipServer.Data.Models
{
    [Table("Hulls")]
    [Index(nameof(Name))]
    [Index(nameof(Mass))]
    [Index(nameof(Armor))]
    public class Hull
    {
        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        public required string Name { get; set; }

        public int Mass { get; set; }

        public int Armor { get; set; }
        #endregion
    }
}

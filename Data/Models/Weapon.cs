using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarshipServer.Data.Models
{
    [Table("Weapons")]
    [Index(nameof(Name))]
    [Index(nameof(DamagePerShot))]
    [Index(nameof(ShotsPerSec))]
    [Index(nameof(EnergyDrainPerSec))]
    [Index(nameof(Mass))]
    public class Weapon
    {
        #region Properties  
        [Key]
        [Required]
        public int Id { get; set; }

        public required string Name { get; set; }

        public int DamagePerShot { get; set; }

        public int ShotsPerSec  { get; set; }

        public int EnergyDrainPerSec { get; set; }

        public int Mass { get; set; }
        #endregion
    }
}

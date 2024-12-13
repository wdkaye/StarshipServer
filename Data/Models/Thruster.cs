using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarshipServer.Data.Models
{
    [Table("Thrusters")]
    [Index(nameof(Name))]
    [Index(nameof(ThrustPerSec))]
    [Index(nameof(EnergyDrainPerSec))]
    [Index(nameof(Mass))]
    public class Thruster
    {
        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        public required string Name { get; set; }

        public int ThrustPerSec { get; set; }

        public int EnergyDrainPerSec { get; set; }

        public int Mass { get; set; }
        #endregion
    }
}

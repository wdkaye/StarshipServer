using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
namespace StarshipServer.Data.Models
{
    [Table("Starships")]
    [Index(nameof(Name))]
    [Index(nameof(Owner))]
    [Index(nameof(HullId))]
    [Index(nameof(ReactorId))]
    [Index(nameof(ThrusterId))]
    [Index(nameof(WeaponId))]
    public class Starship
    {
        #region Properties

        [Key]
        [Required]
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Owner { get; set; } = null!;

        [ForeignKey(nameof(Hull))]
        public int HullId { get; set; }

        [ForeignKey(nameof(Reactor))]
        public int ReactorId { get; set; }

        [ForeignKey(nameof(Thruster))]
        public int ThrusterId { get; set; }

        [ForeignKey(nameof(Weapon))]
        public int WeaponId { get; set; }
        #endregion

        #region Navigation Properties
        public Hull? Hull { get; set; }
        public Reactor? Reactor { get; set; }
        public Thruster? Thruster { get; set; }
        public Weapon? Weapon { get; set; }

        #endregion
    }
}

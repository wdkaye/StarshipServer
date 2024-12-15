using StarshipServer.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace StarshipServer.Data
{
    public class StarshipDTO
    {
        #region Properties

        public required string Name { get; set; } = null!;
        public string? HullName { get; set; } = null!;
        public string? ReactorName { get; set; } = null!;
        public string? ThrusterName { get; set; } = null!;
        public string? WeaponName { get; set; } = null!;
        public int MassTotal { get; set; }
        #endregion

        // public int Id { get; set; }
        // public string Owner { get; set; } = null!;


        //[ForeignKey(nameof(Hull))]
        //public int HullId { get; set; }

        //[ForeignKey(nameof(Reactor))]
        //public int ReactorId { get; set; }

        //[ForeignKey(nameof(Thruster))]
        //public int ThrusterId { get; set; }

        //[ForeignKey(nameof(Weapon))]
        //public int WeaponId { get; set; }


        //#region Navigation Properties
        //public Hull? Hull { get; set; }
        //public Reactor? Reactor { get; set; }
        //public Thruster? Thruster { get; set; }
        //public Weapon? Weapon { get; set; }
    }
}

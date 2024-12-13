using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarshipServer.Data.Models
{
    [Table("Reactors")]
    [Index(nameof(Name))]
    [Index(nameof(EnergyMax))]
    [Index(nameof(EnergyGainPerSec))]
    [Index(nameof(Mass))]
    public class Reactor
    {
        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }

        public required string Name { get; set; }

        public int EnergyMax { get; set; }

        public int EnergyGainPerSec { get; set; }

        public int Mass { get; set; }
        #endregion
    }
}

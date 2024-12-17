using System.ComponentModel.DataAnnotations;

namespace StarshipServer.Data
{
    public class ApiLoginRequest
    {
        [Required(ErrorMessage = "Username required.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public required string Password { get; set; }
    }
}

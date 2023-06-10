using Endpoint.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Endpoint.Models.Requests
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
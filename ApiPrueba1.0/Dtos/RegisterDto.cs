using System.ComponentModel.DataAnnotations;

namespace ApiPrueba1._0.Dtos;

    public class RegisterDto
    {
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password{ get; set; }
    }

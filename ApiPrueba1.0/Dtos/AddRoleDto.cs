using System.ComponentModel.DataAnnotations;


namespace ApiPrueba1._0.Dtos;

    public class AddRoleDto
    {
        [Required]
        public string Username{ get; set; }
        [Required]
        public string Password{ get; set; }
        [Required]
        public string Rol{ get; set; }
    }

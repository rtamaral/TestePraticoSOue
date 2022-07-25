using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Nome do usuário :")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Email do usuário :")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}

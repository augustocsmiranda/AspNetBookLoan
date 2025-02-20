using System.ComponentModel.DataAnnotations;

namespace AspNetBookLoan.Dto
{
    public class UsuarioRegisterDto
    {
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Sobrenome!")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Digite um E-Mail Válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a Confirmação de Senhaa!"), Compare("Senha", ErrorMessage = "As Senhas não estão iguais!")]
        public string ConfirmaSenha { get; set; }


    }
}

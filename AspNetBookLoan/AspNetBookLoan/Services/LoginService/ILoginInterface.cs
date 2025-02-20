

using AspNetBookLoan.Dto;
using AspNetBookLoan.Models;

namespace AspNetBookLoan.Services.LoginService
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);


    }
}

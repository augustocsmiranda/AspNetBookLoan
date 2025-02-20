

using AspNetBookLoan.Data;
using AspNetBookLoan.Dto;
using AspNetBookLoan.Models;
using AspNetBookLoan.Services.SenhaService;
using Microsoft.AspNetCore.Mvc;

namespace AspNetBookLoan.Services.LoginService
{
    public class LoginService : ILoginInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public LoginService(ApplicationDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }



        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();


            try
            {
                if (VerificarSeEmailExiste(usuarioRegisterDto)) {
                    response.Mensagem = "E-Mail já cadastrado!";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel()
                {
                    Nome = usuarioRegisterDto.Nome,
                    Sobrenome = usuarioRegisterDto.Sobrenome,
                    Email = usuarioRegisterDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário Cadastrado com Sucesso!";
                return response;
            }
            catch (Exception ex) 
            { 
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }


        }


        private bool VerificarSeEmailExiste(UsuarioRegisterDto usuarioRegisterDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDto.Email);

            if (usuario == null)
            {
                return false;
            }
            return true;
        }
    }
}

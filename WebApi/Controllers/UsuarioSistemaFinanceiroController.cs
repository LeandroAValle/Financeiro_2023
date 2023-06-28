using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioSistemaFinanceiro _InterfaceUsuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _IUsuarioSistemaFinanceiroServico;

        public UsuarioSistemaFinanceiroController(InterfaceUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServico iUsuarioSistemaFinanceiroServico)
        {
            _InterfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
            _IUsuarioSistemaFinanceiroServico = iUsuarioSistemaFinanceiroServico;
        }

        [HttpGet("/api/ListaUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(int idSistema)
        {
            return await _InterfaceUsuarioSistemaFinanceiro.ListaUsuariosSistema(idSistema);
        }

        [HttpPost("/api/CadastraUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastraUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _IUsuarioSistemaFinanceiroServico.CadastraUsuarioNoSistema(
                new UsuarioSistemaFinanceiro
                {
                    IdSistema = idSistema,
                    EmailUsuario = emailUsuario,
                    Administrador = false,
                    SistemaAtual = true
                });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }

        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _InterfaceUsuarioSistemaFinanceiro.GetEntityById(id);

                await _InterfaceUsuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
                
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}

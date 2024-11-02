using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Ganaderia_API.Custom;
using Ganaderia_API.Models;
using Ganaderia_API.Models.DTOs;
using NuGet.Common;

namespace Ganaderia_API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly AppGanaderiaContext _appGanaderiaContext;
        private readonly Utilidades _utilidades;
        public AccesoController(AppGanaderiaContext appGanaderiaContext, Utilidades utilidades)
        {
            _appGanaderiaContext = appGanaderiaContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult>Registrarse(UsuarioDTO objeto)
        {
            var modeloUsuario = new Usuario 
            {
                Nombre = objeto.Nombre,
                Apellido = objeto.Apellido,
                Email = objeto.Email,
                Contrasena = _utilidades.encriptarSHA256(objeto.Contrasena),
                Telefono = objeto.Telefono,
                Ciudad= objeto.Ciudad,
                RolId= objeto.RolId,
            };

            await _appGanaderiaContext.Usuarios.AddAsync(modeloUsuario);
            await _appGanaderiaContext.SaveChangesAsync();

            if (modeloUsuario.Id != 0)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess=true});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _appGanaderiaContext.Usuarios
                .Where(u => 
                u.Email == objeto.Email &&
                u.Contrasena == _utilidades.encriptarSHA256 (objeto.Contrasena)
                ).FirstOrDefaultAsync();

            if(usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK,new { isSuccess = false,Token="" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, Token = _utilidades.generarJWT(usuarioEncontrado)});
        }
    }
}

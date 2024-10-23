using LogicaAplicacion.InterfacesCU.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Dto;
using LogicaDeNegocios.Excpetions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {

        private readonly IAltaUsuario _altaUsuario;
        private readonly IEliminarUsuario _eliminarUsuario;
        private readonly IModificarUsuario _modificarUsuario;
        private readonly IGetUsuario _getUsuario;
        private readonly IGetAllUsuarios _getAllUsuarios;

        public UsuariosController(IAltaUsuario altaUsuario, IEliminarUsuario eliminarUsuario, IModificarUsuario modificarUsuario, IGetUsuario getUsuario, IGetAllUsuarios getAllUsuarios)
        {
            _altaUsuario = altaUsuario;
            _eliminarUsuario = eliminarUsuario;
            _modificarUsuario = modificarUsuario;
            _getUsuario = getUsuario;
            _getAllUsuarios = getAllUsuarios;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_getAllUsuarios.Ejecutar());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public IActionResult Get(int id)
        {
            try
            {
                UsuarioDto uDto = _getUsuario.Ejecutar(id);
                return Ok(uDto);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody] UsuarioDto uDto)
        {
            try
            {
                UsuarioDto uDtoNuevo = _altaUsuario.Ejecutar(uDto);
                return Ok(uDtoNuevo);
            }
            catch (ElementoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Delete(int id)
        {
            try
            {
                _eliminarUsuario.Ejecutar(id);
                return Ok("Usuario eliminado");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Put(int id, [FromBody] UsuarioDto uDto)
        {
            try
            {
                _modificarUsuario.Ejecutar(id, uDto);
                return Ok("Usuario actualizado");
            }
            catch (ElementoInvalidoException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}

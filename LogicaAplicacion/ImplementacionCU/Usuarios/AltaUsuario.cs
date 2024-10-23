using Dto;
using LogicaAplicacion.InterfacesCU.Usuarios;
using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Usuarios
{
    public class AltaUsuario : IAltaUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDto Ejecutar(UsuarioDto uDto)
        {
            Usuario usuario = uDto.ToUsuario();
            usuario.Validar();
            Usuario usuarioGuardadoEnBD = _repositorioUsuario.Alta(usuario);
            UsuarioDto nuevoUsuarioDto = new UsuarioDto(usuarioGuardadoEnBD);
            return nuevoUsuarioDto;
        }
    }
}

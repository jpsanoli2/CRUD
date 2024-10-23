using Dto;
using LogicaAplicacion.InterfacesCU.Usuarios;
using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.Excpetions;
using LogicaDeNegocios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCU.Usuarios
{
    public class GetUsuario : IGetUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public GetUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDto Ejecutar(int id)
        {
            Usuario usuarioObtenido = _repositorioUsuario.Get(id);
            if (usuarioObtenido == null)
            {
                throw new NotFoundException("No se encontro el usuario");
            }
            UsuarioDto usuarioDto = new UsuarioDto(usuarioObtenido);
            return usuarioDto;
        }
    }
}

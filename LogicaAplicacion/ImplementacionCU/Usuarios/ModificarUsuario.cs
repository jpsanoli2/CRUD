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
    public class ModificarUsuario : IModificarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public ModificarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDto Ejecutar(int id, UsuarioDto uDto)
        {
            Usuario usuario = uDto.ToUsuario();
            usuario.Validar();
            Usuario usuarioToUpdate = _repositorioUsuario.Get(id);
            if(usuarioToUpdate == null)
            {
                throw new NotFoundException("No se encontro el usuario");
            }
            usuarioToUpdate.Copiar(usuario);
            Usuario usuarioModificado = _repositorioUsuario.Modificar(usuarioToUpdate);
            UsuarioDto usuarioModificadoDto = new UsuarioDto(usuarioModificado);
            return usuarioModificadoDto;
        }
    }
}

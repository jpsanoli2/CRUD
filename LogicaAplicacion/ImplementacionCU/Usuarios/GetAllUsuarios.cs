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
    public class GetAllUsuarios : IGetAllUsuarios
    {
        private IRepositorioUsuario _repositorioUsuario;
        public GetAllUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<UsuarioDto> Ejecutar()
        {
            List<UsuarioDto> usuariosDto = new List<UsuarioDto>();
            IEnumerable<Usuario> usuarios = _repositorioUsuario.GetAllUsuarios();
            foreach (Usuario u in usuarios)
            {
                usuariosDto.Add(new UsuarioDto(u));
            }
            return usuariosDto;
        }
    }
}

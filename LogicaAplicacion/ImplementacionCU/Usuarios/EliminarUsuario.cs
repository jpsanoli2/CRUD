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
    public class EliminarUsuario : IEliminarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public EliminarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id)
        {
            Usuario usuario = _repositorioUsuario.Get(id);
            if(usuario == null)
            {
                throw new NotFoundException("Usuario no encontrado");
            }
            _repositorioUsuario.Eliminar(usuario);
        }
    }
}

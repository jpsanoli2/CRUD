using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(DbContext contexto) : base(contexto) 
        { 
        
        }
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _contexto.Set<Usuario>();
        }
    }
}

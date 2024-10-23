using LogicaDeNegocios.Excpetions;
using LogicaDeNegocios.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using IIdentity = LogicaDeNegocios.InterfacesEntidades.IIdentity;

namespace LogicaDeNegocios.Entidades
{
    public class Usuario : IValidable, IIdentity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Usuario() { }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new ElementoInvalidoException("El campo nombre no puede ser vacio");
        }
        public void Copiar(Usuario u)
        {
            Nombre = u.Nombre;
            Apellido = u.Apellido;
            FechaNacimiento = u.FechaNacimiento;
        }
    }
}

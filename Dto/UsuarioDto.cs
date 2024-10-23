using LogicaDeNegocios.Entidades;

namespace Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public UsuarioDto() { }
        public UsuarioDto(Usuario u) 
        {
            Id = u.Id;
            Nombre = u.Nombre;
            Apellido = u.Apellido;
            FechaNacimiento = u.FechaNacimiento;
        }
        public Usuario ToUsuario()
        {
            Usuario u = new Usuario()
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                FechaNacimiento = FechaNacimiento
            };
            return u;
        }
    }
}

﻿using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.Usuarios
{
    public interface IModificarUsuario
    {
        UsuarioDto Ejecutar(int id, UsuarioDto uDto);
    }
}

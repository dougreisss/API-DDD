﻿using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IUsuario
    {
        Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular, TipoUsuario tipoUsuario);
        Task<bool> ExisteUsuario(string email, string senha);

    }
}

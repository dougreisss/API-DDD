﻿using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoUsuario
    {
        Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular, TipoUsuario tipoUsuario);
        Task<bool> ExisteUsuario(string email, string senha);
        Task<string> RetornaIdUsuario(string email);

    }
}

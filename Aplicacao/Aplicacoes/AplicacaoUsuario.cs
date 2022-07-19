using Aplicacao.Interfaces;
using Dominio.Interface;
using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        IUsuario _IUsuario;

        public AplicacaoUsuario(IUsuario usuario)
        {
            _IUsuario = usuario;
        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular, TipoUsuario tipoUsuario)
        {
            return await _IUsuario.AdicionaUsuario(email, senha, idade, celular, tipoUsuario);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _IUsuario.ExisteUsuario(email, senha);
        }

        public async Task<string> RetornaIdUsuario(string email)
        {
            return await _IUsuario.RetornaIdUsuario(email);
        }
    }
}

using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly IAplicacaoNoticia _IAplicacaoNoticia;

        public NoticiaController(IAplicacaoNoticia aplicacaoNoticia)
        {
            _IAplicacaoNoticia = aplicacaoNoticia;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("ListarNoticias")]
        public async Task<List<Noticia>> ListarNoticias()
        {
            try
            {
                return await _IAplicacaoNoticia.ListarNoticiasAtivas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("AdicionaNoticia")]
        public async Task<List<Notifica>> AdicionaNoticia(NoticiaModel noticia)
        {
            try
            {
                var novaNoticia = new Noticia();
                novaNoticia.Titulo = noticia.Titulo;
                novaNoticia.Informacao = noticia.Informacao;
                novaNoticia.UserId = RetornarIdUsuarioLogado();

                await _IAplicacaoNoticia.AdicionaNoticia(novaNoticia);

                return novaNoticia.Notificacoes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("AtualizarNoticia")]
        public async Task<List<Notifica>> AtualizarNoticia(NoticiaModel noticia)
        {
            try
            {
                var novaNoticia = await _IAplicacaoNoticia.BuscarPorId(noticia.IdNoticia);
                novaNoticia.Titulo = noticia.Titulo;
                novaNoticia.Informacao = noticia.Informacao;
                novaNoticia.UserId = RetornarIdUsuarioLogado();

                await _IAplicacaoNoticia.AtualizaNoticia(novaNoticia);

                return novaNoticia.Notificacoes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("ExcluirNoticia")]
        public async Task<List<Notifica>> ExcluirNoticia(NoticiaModel noticia)
        {
            try
            {
                var novaNoticia = await _IAplicacaoNoticia.BuscarPorId(noticia.IdNoticia);

                await _IAplicacaoNoticia.Excluir(novaNoticia);

                return novaNoticia.Notificacoes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("BuscarNoticiaPorId")]
        public async Task<Noticia> BuscarNoticiaPorId(NoticiaModel noticia)
        {
            try
            {
                var novaNoticia = await _IAplicacaoNoticia.BuscarPorId(noticia.IdNoticia);

                return novaNoticia;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private string RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Zaion_API.Data;
using Zaion_API.Models;

namespace Zaion_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadorController : Controller
    {

        public readonly IRepository repository;
        public JogadorController(IRepository rep)
        {
            this.repository = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllJogadoresAsync();
            return Ok(result);
        }

        [HttpGet("{Key}")]
        public async Task<IActionResult> Get(int key)
        {
            try
            {
                var result = await repository.GetJogadorByKeyAsync(key);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpGet("nome/{Nome}")]
        public async Task<IActionResult> GetByName(string nome)
        {
            try
            {
                var result = await repository.GetJogadoresByNameAsync(nome);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpGet("username/{Nome}")]
        public async Task<IActionResult> GetByUsername(string nome)
        {
            try
            {
                var result = await repository.GetJogadoresByUsernameAsync(nome);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> post(Jogador model)
        {
            try
            {
                repository.Add(model);
                if (await repository.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/jogador/{model.IdJogador}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{IdJogador}")]
        public async Task<IActionResult> Put(int key, Jogador dadosJogadorAlt)
        {
            try
            {
                //verifica se existe jogador a ser alterado
                var result = await repository.GetJogadorByKeyAsync(key);

                if (result == null)
                {
                    return BadRequest();
                }
                result = dadosJogadorAlt;

                await repository.SaveChangesAsync();
                return Created($"/jogador/{key}", dadosJogadorAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("remover/{IdJogador}")]
        public async Task<ActionResult> delete(int key)
        {
            try
            {
                //verifica se existe jogador a ser excluído
                var jogador = await repository.GetJogadorByKeyAsync(key);
                if (jogador == null)
                {
                    //método do EF
                    return NotFound();
                }
                repository.Delete(jogador);
                await repository.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu deletar
            //return BadRequest();
        }
    }
}
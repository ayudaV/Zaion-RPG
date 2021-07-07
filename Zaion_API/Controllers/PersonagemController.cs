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
    public class PersonagemController : Controller
    {

        public readonly IRepository repository;
        public PersonagemController(IRepository rep)
        {
            this.repository = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllPersonagensAsync();
            return Ok(result);
        }
        [HttpGet("personagemJogador")]
        public async Task<IActionResult> GetAllPersonagensJogador()
        {
            var result = await repository.GetAllPersonagensJogadorAsync();
            return Ok(result);
        }
        [HttpGet("{Key}")]
        public async Task<IActionResult> Get(int key)
        {
            try
            {
                var result = await repository.GetPersonagemByKeyAsync(key);
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
                var result = await repository.GetPersonagemByNameAsync(nome);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpGet("jogador/{Nome}")]
        public async Task<IActionResult> GetByJogador(int nome)
        {
            try
            {
                var result = await repository.GetPersonagemByJogadorAsync(nome);
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
        public async Task<ActionResult> post(Personagem model)
        {
            try
            {
                repository.Add(model);
                if (await repository.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/personagem/{model.IdPersonagem}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{IdPersonagem}")]
        public async Task<IActionResult> Put(int key, Personagem dadosPersonagemAlt)
        {
            try
            {
                //verifica se existe personagem a ser alterado
                var result = await repository.GetPersonagemByKeyAsync(key);

                if (result == null)
                {
                    return BadRequest();
                }
                result = dadosPersonagemAlt;

                await repository.SaveChangesAsync();
                return Created($"/personagem/{key}", dadosPersonagemAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("remover/{IdPersonagem}")]
        public async Task<ActionResult> delete(int key)
        {
            try
            {
                //verifica se existe personagem a ser excluído
                var personagem = await repository.GetPersonagemByKeyAsync(key);
                if (personagem == null)
                {
                    //método do EF
                    return NotFound();
                }
                repository.Delete(personagem);
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
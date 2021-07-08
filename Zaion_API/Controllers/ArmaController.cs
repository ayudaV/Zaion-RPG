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
    public class ArmaController : Controller
    {

        public readonly IRepository repository;
        public ArmaController(IRepository rep)
        {
            this.repository = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllArmasAsync();
            return Ok(result);
        }

        [HttpGet("{Key}")]
        public async Task<IActionResult> Get(int key)
        {
            try
            {
                var result = await repository.GetArmaByKeyAsync(key);
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
                var result = await repository.GetArmasByNameAsync(nome);
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
        public async Task<ActionResult> post(Arma model)
        {
            try
            {
                repository.Add(model);
                if (await repository.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/arma/{model.IdArma}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{IdArma}")]
        public async Task<IActionResult> Put(int key, Arma dadosArmaAlt)
        {
            try
            {
                //verifica se existe arma a ser alterado
                var result = await repository.GetArmaByKeyAsync(key);

                if (result == null)
                {
                    return BadRequest();
                }
                result = dadosArmaAlt;

                await repository.SaveChangesAsync();
                return Created($"/arma/{key}", dadosArmaAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("remover/{IdArma}")]
        public async Task<ActionResult> delete(int key)
        {
            try
            {
                //verifica se existe arma a ser excluído
                var arma = await repository.GetArmaByKeyAsync(key);
                if (arma == null)
                {
                    //método do EF
                    return NotFound();
                }
                repository.Delete(arma);
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
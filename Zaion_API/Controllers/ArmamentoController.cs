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
    public class ArmamentoController : Controller
    {

        public readonly IRepository repository;
        public ArmamentoController(IRepository rep)
        {
            this.repository = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllArmamentosAsync();
            return Ok(result);
        }

        [HttpGet("{Key}")]
        public async Task<IActionResult> Get(int key)
        {
            try
            {
                var result = await repository.GetArmamentoByKeyAsync(key);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpGet("personagem/{Key}")]
        public async Task<IActionResult> GetByIdPersonagem(int key)
        {
            try
            {
                var result = await repository.GetArmamentoByIdPersonagemAsync(key);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
        [HttpGet("arma/{Key}")]
        public async Task<IActionResult> GetByIdArma(int key)
        {
            try
            {
                var result = await repository.GetArmamentoByIdArmaAsync(key);
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
        public async Task<ActionResult> post(Armamento model)
        {
            try
            {
                repository.Add(model);
                if (await repository.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/item/{model.IdArmamento}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{IdArmamento}")]
        public async Task<IActionResult> Put(int key, Armamento dadosArmamentoAlt)
        {
            try
            {
                //verifica se existe item a ser alterado
                var result = await repository.GetArmamentoByKeyAsync(key);

                if (result == null)
                {
                    return BadRequest();
                }
                result = dadosArmamentoAlt;

                await repository.SaveChangesAsync();
                return Created($"/item/{key}", dadosArmamentoAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("remover/{IdArmamento}")]
        public async Task<ActionResult> delete(int key)
        {
            try
            {
                //verifica se existe item a ser excluído
                var item = await repository.GetArmamentoByKeyAsync(key);
                if (item == null)
                {
                    //método do EF
                    return NotFound();
                }
                repository.Delete(item);
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
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
    public class ItemController : Controller
    {

        public readonly IRepository repository;
        public ItemController(IRepository rep)
        {
            this.repository = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllItensAsync();
            return Ok(result);
        }

        [HttpGet("{Key}")]
        public async Task<IActionResult> Get(int key)
        {
            try
            {
                var result = await repository.GetItemByKeyAsync(key);
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
                var result = await repository.GetItensByNameAsync(nome);
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
        public async Task<ActionResult> post(Item model)
        {
            try
            {
                repository.Add(model);
                if (await repository.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/item/{model.IdItem}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{IdItem}")]
        public async Task<IActionResult> Put(int key, Item dadosItemAlt)
        {
            try
            {
                //verifica se existe item a ser alterado
                var result = await repository.GetItemByKeyAsync(key);

                if (result == null)
                {
                    return BadRequest();
                }
                result = dadosItemAlt;

                await repository.SaveChangesAsync();
                return Created($"/item/{key}", dadosItemAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("remover/{IdItem}")]
        public async Task<ActionResult> delete(int key)
        {
            try
            {
                //verifica se existe item a ser excluído
                var item = await repository.GetItemByKeyAsync(key);
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
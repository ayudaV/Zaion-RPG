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
    public class InventarioController : Controller
    {

        public readonly IRepository repository;
        public InventarioController(IRepository rep)
        {
            this.repository = rep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await repository.GetAllInventariosAsync();
            return Ok(result);
        }

        [HttpGet("{Key}")]
        public async Task<IActionResult> Get(int key)
        {
            try
            {
                var result = await repository.GetInventarioByKeyAsync(key);
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
                var result = await repository.GetInventarioByIdPersonagemAsync(key);
                if (result == null)
                    return this.StatusCode(StatusCodes.Status404NotFound);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpGet("item/{Key}")]
        public async Task<IActionResult> GetByIdItem(int key)
        {
            try
            {
                var result = await repository.GetInventarioByIdItemAsync(key);
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
        public async Task<ActionResult> post(Inventario model)
        {
            try
            {
                repository.Add(model);
                if (await repository.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/item/{model.IdInventario}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{IdInventario}")]
        public async Task<IActionResult> Put(int key, Inventario dadosInventarioAlt)
        {
            try
            {
                //verifica se existe item a ser alterado
                var result = await repository.GetInventarioByKeyAsync(key);

                if (result == null)
                {
                    return BadRequest();
                }
                result = dadosInventarioAlt;

                await repository.SaveChangesAsync();
                return Created($"/item/{key}", dadosInventarioAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("remover/{IdInventario}")]
        public async Task<ActionResult> delete(int key)
        {
            try
            {
                //verifica se existe item a ser excluído
                var item = await repository.GetInventarioByKeyAsync(key);
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
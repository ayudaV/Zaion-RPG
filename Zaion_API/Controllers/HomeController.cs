using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zaion_API.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Zaion_API.Data;
using Zaion_API.Services;
using Microsoft.AspNetCore.Http;

namespace Zaion_API.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly DataBaseContext _repository;
        public HomeController(DataBaseContext repository)
        {
            // construtor
            _repository = repository;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Jogador usuario)
        {
            //verifica se existe aluno a ser excluído
            var user = _repository.Jogador 
            .Where(u => u.Username == usuario.Username && u.Senha == usuario.Senha)
            .FirstOrDefault();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Signup([FromBody] Jogador usuario)
        {
            //verifica se existe aluno a ser excluído
            try
            {
                _repository.Add(usuario);
                if (await _repository.SaveChangesAsync() == 1)
                    return Ok();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado -{0}", User.Identity.Name);

        [HttpGet]
        [Route("jogador")]
        [Authorize(Roles = "jogador,admin")]
        public string Jogador() => "Jogador";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => "Admin";
    }
}
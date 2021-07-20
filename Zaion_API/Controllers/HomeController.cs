using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zaion_API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Zaion_API.Data;
using Zaion_API.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Zaion_API.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IRepository repository;
        private readonly IWebHostEnvironment hostEnvironment;
        public HomeController(IRepository rep, IWebHostEnvironment hostEnvironment)
        {
            // construtor
            this.repository = rep;
            this.hostEnvironment = hostEnvironment;
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Jogador usuario)
        {
            //verifica se existe aluno a ser excluído
            var user = await repository.GetJogadorByUsernameSenha(usuario.Username, usuario.Senha);

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
                usuario.NomeImagem = await SaveImage(usuario.ArquivoImagem);
                if(repository.GetJogadoresByUsernameAsync(usuario.Username) != null)
                return BadRequest("Nome de Usuario ja utilizado.");
                repository.Add(usuario);
                if (await repository.SaveChangesAsync())
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

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
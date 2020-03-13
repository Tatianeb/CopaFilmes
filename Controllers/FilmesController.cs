using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Domain;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService filmeService;
        public FilmesController(IFilmeService filmeService)
        {
            this.filmeService = filmeService;
        }

        /// <summary>
        /// Listar todos os filmes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        async public Task<IEnumerable<Filme>> Get()
        {
            var filmes = await filmeService.ListAll();
            return filmes;
        }

    }
}

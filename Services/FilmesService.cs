using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CopaFilmes.Domain;

namespace CopaFilmes.Services
{
    public class FilmeService : IFilmeService
    {
        private const string URL = "http://copafilmes.azurewebsites.net/api/filmes";

        // traz todos os filmes da api copafilmes.azurewebsites
        public async Task<IEnumerable<Filme>> ListAll()
        {
            var filmes = new List<Filme>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(URL);
                filmes = await response.Content.ReadAsAsync<List<Filme>>();
            }

            return filmes;
        }
    }
}
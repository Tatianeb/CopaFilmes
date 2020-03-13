using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Domain;

namespace CopaFilmes.Services
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> ListAll();
    }
}
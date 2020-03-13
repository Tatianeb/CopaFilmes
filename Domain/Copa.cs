using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain
{
    public class Copa
    {
        public List<Filme> Filmes { get; set; }
        public List<Batalha> Confrontos { get; set; }
        public Filme FilmeCampeao { get; set; }
        public Filme FilmeViceCampeao { get; set; }

        public bool ResolverFase()
        {
            List<Filme> FilmesClassificados = new List<Filme>();
            foreach (Batalha confronto in Confrontos)
            {
                if (confronto.Classificacao())
                {
                    if (Confrontos.ToList().Count == 1)
                    {
                        FilmeCampeao = confronto.FilmeVencedor;
                        FilmeViceCampeao = confronto.FilmePerdedor;
                    }
                    else
                    {
                        FilmesClassificados.Add(confronto.FilmeVencedor);
                    }
                }
            }
            Filmes = FilmesClassificados;
            return true;
        }
    }
}

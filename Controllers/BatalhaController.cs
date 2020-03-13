using CopaFilmes.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Controllers
{
    public class BatalhaController 
    {
       
        public Copa Copa(List<Filme> Filmes)
        {
            Copa campeonato = new Copa { Filmes = Filmes.OrderBy(f => f.Titulo).ToList() };
            campeonato.Confrontos = ConfrontosIniciais(campeonato.Filmes.ToList());
            Campeao(campeonato);
            return campeonato;
        }

        public List<Batalha> ConfrontosIniciais(List<Filme> Filmes)
        {
            var ListaConfrontos = new List<Batalha>();
            while (Filmes.Count > 0)
            {
                ListaConfrontos.Add(new Batalha(Filmes[0], Filmes[Filmes.Count - 1]));
                Filmes.RemoveAt(Filmes.Count - 1);
                Filmes.RemoveAt(0);
            }
            return ListaConfrontos;
        }

        private void Campeao(Copa campeonato)
        {
            while (campeonato.FilmeCampeao == null || string.IsNullOrEmpty(campeonato.FilmeCampeao.Id))
            {
                if (campeonato.ResolverFase())
                {
                    campeonato.Confrontos = BatalhaFinal(campeonato.Filmes.ToList());
                }
                else
                {
                    break;
                }
            }
        }

        public List<Batalha> BatalhaFinal(List<Filme> Filmes)
        {
            List<Batalha> ListaConfrontos = new List<Batalha>();
            while (Filmes.Count > 0)
            {
                ListaConfrontos.Add(new Batalha(Filmes[0], Filmes[1]));
                Filmes.RemoveAt(1);
                Filmes.RemoveAt(0);
            }
            return ListaConfrontos;
        }
    }
}

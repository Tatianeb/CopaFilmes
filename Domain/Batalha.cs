using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain
{
    public class Batalha
    {
        public Filme FilmeA { get; set; }
        public Filme FilmeB { get; set; }
        public Filme FilmeVencedor { get; set; }
        public Filme FilmePerdedor { get; set; }

        public Batalha(Filme FilmeA, Filme FilmeB)
        {
            this.FilmeA = FilmeA;
            this.FilmeB = FilmeB;
            this.FilmeVencedor = null;
        }

        public bool Classificacao()
        {
            if (FilmeA.Nota > FilmeB.Nota)
            {
                FilmeVencedor = FilmeA;
                FilmePerdedor = FilmeB;
            }
            else if (FilmeA.Nota < FilmeB.Nota)
            {
                FilmeVencedor = FilmeB;
                FilmePerdedor = FilmeA;
            }
            else
                FilmeVencedor = Desempate();

            return true;
        }

        public Filme Desempate(int index = 0)
        {
            if (FilmeA.Titulo[index] < FilmeB.Titulo[index])
                return FilmeA;
            else if (FilmeA.Titulo[index] > FilmeB.Titulo[index])
                return FilmeB;
            else
                return string.Compare(FilmeA.Titulo, FilmeB.Titulo, StringComparison.Ordinal) < 0 ? FilmeA : FilmeB;
        }
    }
}


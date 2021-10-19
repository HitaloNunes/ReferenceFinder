using ReferenceFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Dominio
{
    public class DominioVersiculo
    {
        DominioAbreviacoes domAbreviacoes;
        public Texto retornarVersiculo(Biblia biblia, Referencia referencia)
        {
            Texto retorno = new Texto();
            List<Versiculo> Versiculo = new List<Versiculo>();
            int i = 0;
            domAbreviacoes = new DominioAbreviacoes();
            var abrev = domAbreviacoes.gerarListaAbreviacoes(biblia);
            for(i = 0; i < abrev.Length; i++)
            {
                if(abrev[i].Abreviacao == referencia.Livro)
                {
                    retorno.Livro = abrev[i];
                    break;
                }
            }
            if (retorno.Livro == null)
            {
                retorno.Capitulo = 999;
                Versiculo.Add(new Versiculo { Indice = 999, Verso = "Livro não Encontrado!" });
                retorno.Versos = Versiculo.ToArray();
            } else if (referencia.Capitulo - 1 >= biblia.Livros[i].chapters.Length)
            {
                retorno.Capitulo = 999;
                Versiculo.Add(new Versiculo { Indice = 999, Verso = "Capítulo não Encontrado!" });
                retorno.Versos = Versiculo.ToArray();
            } else if (referencia.Versiculo - 1 >= biblia.Livros[i].chapters[referencia.Capitulo - 1].Length)
            {
                retorno.Capitulo = 999;
                Versiculo.Add(new Versiculo { Indice = 999, Verso = "Versículo não Encontrado!" });
                retorno.Versos = Versiculo.ToArray();
            } else
            {
                retorno.Capitulo = referencia.Capitulo;
                Versiculo.Add(new Versiculo { Indice = referencia.Versiculo, Verso = biblia.Livros[i].chapters[referencia.Capitulo - 1][referencia.Versiculo - 1] });
                retorno.Versos = Versiculo.ToArray();
            }

            return retorno;
        }

        public Texto retornarVersiculos(Biblia biblia, Referencia referencia)
        {
            Texto retorno = new Texto();
            List<Versiculo> Versiculo = new List<Versiculo>();
            int i = 0;
            int j = 0;
            domAbreviacoes = new DominioAbreviacoes();
            var abrev = domAbreviacoes.gerarListaAbreviacoes(biblia);
            for (i = 0; i < abrev.Length; i++)
            {
                if (abrev[i].Abreviacao == referencia.Livro)
                {
                    retorno.Livro = abrev[i];
                    break;
                }
            }
            if (retorno.Livro == null)
            {
                retorno.Capitulo = 999;
                Versiculo.Add(new Versiculo { Indice = 999, Verso = "Livro não Encontrado!" });
                retorno.Versos = Versiculo.ToArray();
                return retorno;
            } else
            {
                retorno.Capitulo = referencia.Capitulo;
                for(j = 0; j < referencia.Versiculos.Length; j++)
                {
                    if (referencia.Capitulo - 1 >= biblia.Livros[i].chapters.Length)
                    {
                        Versiculo.Add(new Versiculo { Indice = 999, Verso = "Capítulo não Encontrado!" });
                        retorno.Versos = Versiculo.ToArray();
                    }
                    else if (referencia.Versiculos[j] - 1 >= biblia.Livros[i].chapters[referencia.Capitulo - 1].Length)
                    {
                        Versiculo.Add(new Versiculo { Indice = 999, Verso = "Versículo não Encontrado!" });
                        retorno.Versos = Versiculo.ToArray();
                    }
                    else
                    {
                        Versiculo.Add(new Versiculo { Indice = referencia.Versiculos[j], Verso = biblia.Livros[i].chapters[referencia.Capitulo - 1][referencia.Versiculos[j] - 1] });
                        retorno.Versos = Versiculo.ToArray();
                    }
                }

                
                return retorno;
            }
        }

        public Texto[] resultadosPorExpressao(Biblia biblia, string Trecho)
        {
            List<Texto> retorno = new List<Texto>();
            List<Versiculo> citacoes;
            Texto trecho;
            Versiculo versiculo;
            domAbreviacoes = new DominioAbreviacoes();
            Abreviacoes[] abreviacoes = domAbreviacoes.gerarListaAbreviacoes(biblia);
            int i, j;
            foreach(var item in biblia.Livros)
            {
                for(i = 0; i < item.chapters.Length; i++)
                {
                    trecho = new Texto();
                    citacoes = new List<Versiculo>();
                    trecho.Livro = domAbreviacoes.buscarLivro(item.abbrev, abreviacoes);
                    trecho.Capitulo = i + 1;
                    for (j = 0; j < item.chapters[i].Length; j++)
                    {
                        if (item.chapters[i][j].ToLower().Contains(Trecho.ToLower()))
                        {
                            versiculo = new Versiculo();
                            versiculo.Indice = j + 1;
                            versiculo.Verso = item.chapters[i][j];
                            citacoes.Add(versiculo);
                        }
                    }
                    if(citacoes.Count() > 0)
                    {
                        trecho.Versos = citacoes.ToArray();
                        retorno.Add(trecho);
                    }
                }
            }

            return retorno.ToArray();
        }
    }
}

using ReferenceFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Dominio
{
    public class DominioAbreviacoes
    {
        public static string[] livros = { "Gênesis", "Êxodo", "Levítico", "Números", "Deuteronômio", "Josué", "Juízes", "Rute", "I Samuel", "II Samuel", "I Reis", "II Reis", "I Crônicas", "II Crônicas", "Esdras", "Neemias", "Ester", "Jó", "Salmos", "Provérbios", "Eclesiastes", "Cânticos dos Cânticos", "Isaías", "Jeremias", "Lamentações", "Ezequiel", "Daniel", "Oseias", "Joel", "Amós", "Obadias", "Jonas", "Miqueias", "Naum", "Habacuque", "Sofonias", "Ageu", "Zacarias", "Malaquias", "Mateus", "Marcos", "Lucas", "João", "Atos dos Apóstolos", "Romanos", "I Coríntios", "II Coríntios", "Gálatas", "Efésios", "Filipenses", "Colossenses", "I Tessalonicenses", "II Tessalonicenses", "I Timóteo", "II Timóteo", "Tito", "Filémon", "Hebreus", "Tiago", "I Pedro", "II Pedro", "I João", "II João", "III João", "Judas", "Apocalipse" };
        public Abreviacoes[] gerarListaAbreviacoes (Biblia biblia)
        {
            List<Abreviacoes> retorno = new List<Abreviacoes>();
            int i = 0;
            foreach(var item in biblia.Livros)
            {
                retorno.Add(new Abreviacoes { Abreviacao = item.abbrev, Nome = livros[i] });
                i++;
            }

            return retorno.ToArray();

        }

        public Abreviacoes buscarLivro(string abrev, Abreviacoes[] lista)
        {
            for(int i = 0; i < lista.Length; i++)
            {
                if(lista[i].Abreviacao == abrev)
                {
                    return lista[i];
                }
            }
            return null;
        }
    }
}

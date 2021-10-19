using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Models
{
    public class Referencia
    {
        public string Contexto { get; set; }
        public string Livro { get; set; }
        public int Capitulo { get; set; }
        public int Versiculo { get; set; }
        public int[] Versiculos { get; set; }
        public string Trecho { get; set; }

        public Referencia(string referencia)
        {
            string[] livro = referencia.Split(' ');
            string[] capitulo = livro[1].Split(':');
            string[] versiculo;
            Contexto = referencia;
            Livro = livro[0].ToLower();
            Capitulo = Convert.ToInt32(capitulo[0]);
            if (livro[1].Contains(','))
            {
                versiculo = capitulo[1].Split(',');
                Versiculos = new int[versiculo.Length];
                for(int i = 0; i < versiculo.Length; i++)
                {
                    Versiculos[i] = Convert.ToInt32(versiculo[i]);
                }
            } else
            {
                Versiculo = Convert.ToInt32(capitulo[1]);
            }
        }
    }
}

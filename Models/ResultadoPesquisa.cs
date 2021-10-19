using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Models
{
    public class ResultadoPesquisa
    {
        public int Quantidade { get; set; }
        public Texto[] Resultados { get; set; }
    }
}

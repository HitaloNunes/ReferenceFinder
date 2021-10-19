using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Models
{
    public class Texto
    {
        public Abreviacoes Livro { get; set; }
        public int Capitulo { get; set; }
        public Versiculo[] Versos { get; set; }
    }
}

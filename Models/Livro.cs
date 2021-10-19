using ReferenceFinder.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Models
{
    public class Livro
    {
        public string abbrev { get; set; }
        public string[][] chapters { get; set; }
    }
}

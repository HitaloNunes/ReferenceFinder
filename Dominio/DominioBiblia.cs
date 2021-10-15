using Newtonsoft.Json;
using ReferenceFinder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Dominio
{
    public class DominioBiblia
    {
        public Biblia abrirBiblia()
        {
            Biblia retorno = new Biblia();
            List<Livro> livros = new List<Livro>();
            StreamReader text = new StreamReader("Assets\\acf.json");
            //var tarefa = JsonConvert.DeserializeObject<Dictionary<string, string>>(text.ReadToEnd());
            livros = JsonConvert.DeserializeObject<List<Livro>>(text.ReadToEnd());
            retorno.Livros = livros.ToArray();

            return retorno;
        }
    }
}

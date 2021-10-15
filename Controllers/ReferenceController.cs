using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferenceFinder.Dominio;
using ReferenceFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        DominioBiblia domBiblia;
        [HttpPost]
        public ActionResult<string>buscarReferencia([FromBody]string Busca)
        {
            domBiblia = new DominioBiblia();
            int i, j;
            StringBuilder retorno = new StringBuilder();
            Referencia referencia;
            if (Busca.Contains(' ') && Busca.Contains(':'))
            {
                referencia = new Referencia(Busca);
            } else
            {
                return "Sua referência não está dentro dos padrões!";
            }
            var biblia = domBiblia.abrirBiblia();
            for (i = 0; i < biblia.Livros.Length; i++)
            {
                if(biblia.Livros[i].abbrev == referencia.Livro)
                {
                    if(biblia.Livros[i].chapters[referencia.Capitulo - 1].Length <= referencia.Versiculo)
                    {
                        retorno.Append("Versículo fora do alcance!");
                    }
                    else
                    {
                        if (referencia.Versiculos != null)
                        {
                            for (j = 0; j < referencia.Versiculos.Length; j++)
                            {
                                if (biblia.Livros[i].chapters[referencia.Capitulo - 1].Length <= referencia.Versiculos[j] - 1)
                                {
                                    retorno = new StringBuilder();
                                    retorno.Append("Texto fora do alcance!");
                                    break;
                                } else
                                {
                                    retorno.Append(referencia.Versiculos[j] + ". " + biblia.Livros[i].chapters[referencia.Capitulo - 1][referencia.Versiculos[j] - 1]);
                                    if (j < referencia.Versiculos.Length - 1)
                                    {
                                        retorno.AppendLine();
                                    }
                                }
                            }
                        }
                        else
                        {
                            retorno.Append(referencia.Versiculo + ". " + biblia.Livros[i].chapters[referencia.Capitulo - 1][referencia.Versiculo - 1]);
                        }
                    }
                    break;
                }
            }
            if (retorno.ToString() == "")
            {
                retorno.Append("Referência não encontrada!");
            }

            return retorno.ToString();
        }
    }
}

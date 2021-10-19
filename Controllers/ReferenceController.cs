using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        DominioVersiculo domVersiculo;
        DominioResultadoPesquisa domResult;
        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public ActionResult<string>buscarReferencia([FromBody]string Busca)
        {
            domBiblia = new DominioBiblia();
            domVersiculo = new DominioVersiculo();
            Referencia referencia;
            if (Busca.Contains(' ') && Busca.Contains(':'))
            {
                referencia = new Referencia(Busca);
            } else
            {
                return "Sua referência não está dentro dos padrões!";
            }
            var biblia = domBiblia.abrirBiblia();
            if (referencia.Versiculo > 0)
            {
                Texto texto = domVersiculo.retornarVersiculo(biblia, referencia);
                switch (texto.Versos[0].Verso)
                {
                    case "Livro não Encontrado!":
                        return texto.Versos[0].Verso;
                        break;
                    case "Capítulo não Encontrado!":
                        return texto.Versos[0].Verso;
                        break;
                    case "Versículo não Encontrado!":
                        return texto.Versos[0].Verso;
                        break;
                    default:
                        return JsonConvert.SerializeObject(texto);
                        break;
                }
            } else
            {
                Texto texto = domVersiculo.retornarVersiculos(biblia, referencia);
                return JsonConvert.SerializeObject(texto);
            }
        }

        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public ActionResult<string> buscarTrecho([FromBody] string Trecho)
        {
            domBiblia = new DominioBiblia();
            domResult = new DominioResultadoPesquisa();
            var biblia = domBiblia.abrirBiblia();
            var resultado = domResult.buscarResultados(biblia, Trecho);
            if (resultado.Resultados.Length == 0)
            {
                return "Nenhum Trecho Encontrado!";
            }

            return JsonConvert.SerializeObject(resultado);
        }
    }
}

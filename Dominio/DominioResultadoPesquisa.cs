using ReferenceFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReferenceFinder.Dominio
{
    public class DominioResultadoPesquisa
    {
        DominioVersiculo domVersiculo;
        public ResultadoPesquisa buscarResultados(Biblia biblia, string Trecho)
        {
            ResultadoPesquisa retorno = new ResultadoPesquisa();
            domVersiculo = new DominioVersiculo();
            Texto[] trechos = domVersiculo.resultadosPorExpressao(biblia, Trecho);
            foreach(var item in trechos)
            {
                retorno.Quantidade += item.Versos.Length;
            }
            retorno.Resultados = trechos;

            return retorno;
        }
    }
}

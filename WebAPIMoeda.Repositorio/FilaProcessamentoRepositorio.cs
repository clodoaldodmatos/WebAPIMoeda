using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMoeda.Entidade.DTO;

namespace WebAPIMoeda.Repositorio
{
    public class FilaProcessamentoRepositorio
    {
        private static List<ParametroCotacaoMoeda> filaProcessamento { get; set; } = new List<ParametroCotacaoMoeda>();

        public static ParametroCotacaoMoeda AddItemFila(ParametroCotacaoMoeda ItemProcessamento)
        {
            filaProcessamento.Add(ItemProcessamento);
            return ItemProcessamento;
        }

        public static ParametroCotacaoMoeda popItemFila()
        {
            ParametroCotacaoMoeda retorno = filaProcessamento.Count > 0 ? filaProcessamento[filaProcessamento.Count - 1] : null;
            if (retorno != null)
            {
                filaProcessamento.Remove(retorno);
            }

            return retorno;
        }
    }
}

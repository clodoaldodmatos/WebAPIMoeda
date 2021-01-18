using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMoeda.Entidade.DTO;
using WebAPIMoeda.Repositorio;

namespace WebAPIMoeda.Negocio
{
    public class FilaNegocio
    {
        public void AddItemFilaProcessamento(ParametroCotacaoMoeda ItemProcessamento)
        {
            FilaProcessamentoRepositorio.AddItemFila(ItemProcessamento);
        }

        public void AddListaFilaProcessamento(List<ParametroCotacaoMoeda> listaItensProcessamento)
        {
            foreach (ParametroCotacaoMoeda item in listaItensProcessamento)
            {
                AddItemFilaProcessamento(item);
            }
        }

        public ParametroCotacaoMoeda popItemFilaProcessamento()
        {
            return FilaProcessamentoRepositorio.popItemFila();
        }
    }
}

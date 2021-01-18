using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMoeda.Entidade.DTO;
using WebAPIMoeda.Repositorio;

namespace WebAPIMoeda.Negocio
{
    public class CotacaoMoedaNegocio
    {
        public List<CotacaoMoeda> getListaCotacaoMoedaByItemFilaProcessamento(ParametroCotacaoMoeda itemFilaProcessamento)
        {
            List<CotacaoMoeda> resultadoProcessamento = null;
            List<DadosCotacao> listaDadosCotacao = DadosCotacaoRepositorio.DadosCotacao;
            List<DadosMoeda> listaDadosMoeda = DadosMoedaRepositorio.DadosMoeda;
            List<LigacaoCotacaoMoeda> listaLigacaoCotacaoMoeda = LigacaoCotacaoMoedaRepositorio.LigacaoCotacaoMoeda;

            DadosMoeda dadosMoeda = listaDadosMoeda.Where(q => q.IdMoeda == itemFilaProcessamento.Moeda).FirstOrDefault();
            LigacaoCotacaoMoeda dadosLigacao = listaLigacaoCotacaoMoeda.Where(q => q.IdMoeda == itemFilaProcessamento.Moeda).FirstOrDefault();

            if(dadosLigacao != null)
            {
                List<DadosCotacao> cotacoesResultado = listaDadosCotacao.Where(q =>
                    q.CodCotacao == dadosLigacao.CodCotacao
                    &&
                    q.DataCotacao >= itemFilaProcessamento.DataInicio
                    &&
                    q.DataCotacao <= itemFilaProcessamento.DataFim
                ).ToList();

                resultadoProcessamento = new List<CotacaoMoeda>();

                foreach (DadosCotacao itemCotacao in cotacoesResultado)
                {
                    CotacaoMoeda cotacaoResultado = new CotacaoMoeda()
                    { 
                        IdMoeda = dadosLigacao.IdMoeda,
                        ValorCotacao = itemCotacao.ValorCotacao,
                        DataCotacao = itemCotacao.DataCotacao
                    };

                    resultadoProcessamento.Add(cotacaoResultado);
                }
            }

            gravaResultadoProcessamento(resultadoProcessamento);
            return resultadoProcessamento;
        }

        private void gravaResultadoProcessamento(List<CotacaoMoeda> resultadoProcessamento)
        {
            CotacaoMoedaRepositorio.gravaResultadoCotacaoMoeda(resultadoProcessamento);
        }
    }
}

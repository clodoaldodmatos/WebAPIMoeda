using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPIMoeda.Entidade.DTO;
using WebAPIMoeda.Negocio;
using WebAPIMoeda.Repositorio;

namespace WebAPIMoeda.Controllers
{
    [RoutePrefix("api/Fila")]
    public class FilaController : ApiController
    {
        public FilaNegocio filaNegocio { get; set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            filaNegocio = new FilaNegocio();
        }

        [HttpGet]
        [Route("AddItemFila")]
        public IHttpActionResult AddItemFila([FromBody] List<ParametroCotacaoMoeda> parametros)
        {
            try
            {
                filaNegocio.AddListaFilaProcessamento(parametros);

                return Ok("Itens adicionados com sucesso.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }   
        }

        [HttpGet]
        [Route("GetItemFila")]
        public IHttpActionResult GetItemFila()
        {
            try
            {
                ParametroCotacaoMoeda itemPoped = filaNegocio.popItemFilaProcessamento();

                if (itemPoped == null)
                {
                    return Ok("Não foram encontrados itens na fila de processamento.");
                }
                else
                {
                    return Ok(itemPoped);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetCotacaoItemFila")]
        public IHttpActionResult GetCotacaoItemFila()
        {
            try
            {
                ParametroCotacaoMoeda itemPoped = filaNegocio.popItemFilaProcessamento();

                if (itemPoped == null)
                {
                    return Ok("Não foram encontrados itens na fila de processamento.");
                }
                else
                {
                    CotacaoMoedaNegocio cotacaoMoedaNegocio = new CotacaoMoedaNegocio();
                    List<CotacaoMoeda> resultado = cotacaoMoedaNegocio.getListaCotacaoMoedaByItemFilaProcessamento(itemPoped);

                    return Ok(resultado);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

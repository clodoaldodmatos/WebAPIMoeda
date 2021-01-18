using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMoeda.Entidade.DTO
{
    public class ParametroCotacaoMoeda
    {
        [JsonProperty(PropertyName = "moeda")]
        public string Moeda { get; set; }
        [JsonProperty(PropertyName = "data_inicio")]
        public DateTime DataInicio { get; set; }
        [JsonProperty(PropertyName = "data_fim")]
        public DateTime DataFim { get; set; }
    }
}
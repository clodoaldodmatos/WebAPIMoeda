using CsvHelper.Configuration.Attributes;
using System;

namespace WebAPIMoeda.Entidade.DTO
{
    public class DadosMoeda
    {
        [Index(0)]
        public string IdMoeda { get; set; }
        [Index(1)]
        public DateTime DataReferencia { get; set; }

    }
}

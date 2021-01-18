using CsvHelper.Configuration.Attributes;
using System;

namespace WebAPIMoeda.Entidade.DTO
{
    public class DadosCotacao
    {
        [Index(1)]
        public int CodCotacao { get; set; }
        [Index(0)]
        public float ValorCotacao { get; set; }
        [Index(2)]
        public string StringDataCotacao { get; set; }
        [Optional]
        public DateTime DataCotacao { get; set; }

    }
}

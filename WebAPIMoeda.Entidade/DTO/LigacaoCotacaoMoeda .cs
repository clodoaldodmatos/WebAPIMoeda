using CsvHelper.Configuration.Attributes;
using System;

namespace WebAPIMoeda.Entidade.DTO
{
    public class LigacaoCotacaoMoeda
    {
        [Index(0)]
        public string IdMoeda { get; set; }
        [Index(1)]
        public int CodCotacao { get; set; }
    }
}

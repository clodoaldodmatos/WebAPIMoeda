using System;

namespace WebAPIMoeda.Entidade.DTO
{
    public class CotacaoMoeda
    {
        public string IdMoeda { get; set; }
        public float ValorCotacao { get; set; }
        public DateTime DataCotacao { get; set; }
    }
}

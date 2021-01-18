using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPIMoeda.Entidade.DTO;
using CsvHelper;
using System.Globalization;

namespace WebAPIMoeda.Repositorio
{
    public class LigacaoCotacaoMoedaRepositorio
    {
        public static List<LigacaoCotacaoMoeda> LigacaoCotacaoMoeda { get; } = LoadArquivoCSVDeParaCotacaoMoeda();

        private static List<LigacaoCotacaoMoeda> LoadArquivoCSVDeParaCotacaoMoeda()
        {
            string caminhoArquivoDadosCotacao = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/TABELA_DE_PARA_COTACAO_MOEDA.csv");
            CsvHelper.Configuration.CsvConfiguration csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.Delimiter = ";";
            using (var reader = new StreamReader(caminhoArquivoDadosCotacao))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                List<LigacaoCotacaoMoeda> records = csv.GetRecords<LigacaoCotacaoMoeda>().ToList();

                return records;
            }
        }
    }
}

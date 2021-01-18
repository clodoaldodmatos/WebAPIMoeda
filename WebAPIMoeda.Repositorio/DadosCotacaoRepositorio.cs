using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMoeda.Entidade.DTO;
using System.Web;
using CsvHelper;
using System.Globalization;

namespace WebAPIMoeda.Repositorio
{
    public class DadosCotacaoRepositorio
    {
        public static List<DadosCotacao> DadosCotacao { get; } = LoadArquivoCSVDadosCotacao();

        private static List<DadosCotacao> LoadArquivoCSVDadosCotacao()
        {
            string caminhoArquivoDadosCotacao = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/DadosCotacao.csv");
            CsvHelper.Configuration.CsvConfiguration csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.Delimiter = ";";
            using (var reader = new StreamReader(caminhoArquivoDadosCotacao))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                List<DadosCotacao> records = csv.GetRecords<DadosCotacao>().ToList();

                return ajustaDataDadosCotacao(records);
            }
        }

        private static List<DadosCotacao> ajustaDataDadosCotacao(List<DadosCotacao> listaDadosCotacao)
        {
            foreach (DadosCotacao item in listaDadosCotacao)
            {
                item.DataCotacao = DateTime.ParseExact(item.StringDataCotacao, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            }
            return listaDadosCotacao;
        }
    }
}

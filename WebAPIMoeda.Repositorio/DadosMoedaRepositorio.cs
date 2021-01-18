using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPIMoeda.Entidade.DTO;
using CsvHelper;
using System.Globalization;

namespace WebAPIMoeda.Repositorio
{
    public class DadosMoedaRepositorio
    {
        public static List<DadosMoeda> DadosMoeda { get; } = LoadArquivoCSVDadosMoeda();

        private static List<DadosMoeda> LoadArquivoCSVDadosMoeda()
        {
            string caminhoArquivoDadosMoeda = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/DadosMoeda.csv");
            CsvHelper.Configuration.CsvConfiguration csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfiguration.Delimiter = ";";
            using (var reader = new StreamReader(caminhoArquivoDadosMoeda))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                List<DadosMoeda> records = csv.GetRecords<DadosMoeda>().ToList();

                return records;
            }
        }
    }
}

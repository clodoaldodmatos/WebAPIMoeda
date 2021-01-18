using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPIMoeda.Entidade.DTO;
using CsvHelper;
using System.Globalization;
using System;

namespace WebAPIMoeda.Repositorio
{
    public class CotacaoMoedaRepositorio
    {
        public static void gravaResultadoCotacaoMoeda(List<CotacaoMoeda> resultadoCotacaoMoeda)
        {
            string pastaGravacao = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/");
            string nomeArquivo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + "_" + resultadoCotacaoMoeda[0].IdMoeda + ".csv";
            using (var writer = new StreamWriter(pastaGravacao + nomeArquivo))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(resultadoCotacaoMoeda);
            }
        }
    }
}

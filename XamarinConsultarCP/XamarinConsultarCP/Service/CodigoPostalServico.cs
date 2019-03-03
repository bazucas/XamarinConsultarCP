using System.Net;
using Newtonsoft.Json;
using XamarinConsultarCP.Service.Model;

namespace XamarinConsultarCP.Service
{
    public class CodigoPostalServico
    {
        private const string Address = "http://codigospostais.appspot.com/cp7?codigo={0}";
        private const string Coordinates = "http://codigospostais.appspot.com/cp4?codigo={0}";

        public static Morada GetCpFromService(string cp)
        {
            var newUrl = string.Format(Address, cp);
            var wc = new WebClient();
            var content = wc.DownloadString(newUrl);
            var morada = JsonConvert.DeserializeObject<Morada>(content);
            return morada.Cp7 == null ? null : morada;
        }

        public static Coordenadas GetCoordinatesFromService(string cp)
        {
            var newUrl = string.Format(Coordinates, cp);
            var wc = new WebClient();
            var content = wc.DownloadString(newUrl);
            var coord = JsonConvert.DeserializeObject<Coordenadas>(content);
            return coord.Cp4 == null ? null : coord;
        }
    }
}

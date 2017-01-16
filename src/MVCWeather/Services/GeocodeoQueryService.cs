using tsears.MVCWeather.Services.Geo;
using System.Text;
using System;
using System.Threading.Tasks;
using tsears.MVCWeather.DataStructures;

namespace tsears.MVCWeather.Services.Geo
{
    public class GeocodioQueryService: IGeoQueryService
    {
        private readonly IGeoQueryParser _geoQueryParser;
        private readonly IGeoQueryDispatchService _geoQueryDispatchService;

        public GeocodioQueryService(IGeoQueryParser geoQueryParser, IGeoQueryDispatchService geoQueryDispatchService) {
            _geoQueryParser = geoQueryParser;
            _geoQueryDispatchService = geoQueryDispatchService;
        }

        public async Task<GeoCoordinate> Query(string q) {
            var queryParts = _geoQueryParser.Parse(q);
            var sb = new StringBuilder("https://api.geocod.io/v1/geocode?");
            
            foreach(var k in queryParts.Keys) {
                sb.Append($"{k}={queryParts[k]}&");
            }

            sb.Append("api_key=");
            sb.Append(Environment.GetEnvironmentVariable("GEOCODIO_API_KEY"));

            var query = sb.ToString();

            Console.WriteLine(query);

            return await _geoQueryDispatchService.Query(query).ConfigureAwait(false);
        }
    }
}
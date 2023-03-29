using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RPM_Programming_Excercise.Common;
using RPM_Programming_Excercise.Common.Extensions;
using RPM_Programming_Excercise.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.EiaApi
{
    public class EiaPetroleumApiService : IEiaPetroleumApiService
    {
        private const string apiKey = "EthXWE6eUTrBEJ1uTpNCqbL4NjghRxaC2R5tw1b2";
        private const string petroleumApiUri = "v2/petroleum/pri/gnd/data";
        
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<EiaPetroleumApiService> _logger;

        public EiaPetroleumApiService(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = loggerFactory.CreateLogger<EiaPetroleumApiService>();
        }

        public async Task<List<PetroleumModel>> GetPetroleumData(/*IRequestModel parameters*/)
        {
            // TODO: retrieve the dictionary of params by calling the method GenerateDictionaryOfParams from interface IRequestModel
            var parameters = new Dictionary<string, string>
            {
                { "frequency", "weekly"},
                { "data[]", "value" },
                { "facets[series][]", "EMD_EPD2D_PTE_NUS_DPG" },
                { "sort[0][column]", "period" },
                { "sort[0][direction]", "desc" },
                { "offset", "0"},
                { "length", "5000"},
                { "api_key", apiKey}
            };

            using var httpClient = _httpClientFactory.CreateClient(Constants.EiaPetroleumApiName);
            try
            {
                var httpResponse = await httpClient.GetWithQueryStringAsync(petroleumApiUri, parameters);

                if (httpResponse == null || httpResponse.Content == null)
                {
                    throw new Exception("Invalid HTTP Response");
                }

                var content = await httpResponse.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(jsonObject["error"].ToString());
                    _logger.LogError(jsonObject["error"].ToString());

                    throw new Exception(error.Message);
                }

                var result = JsonConvert.DeserializeObject<BaseResponseModel<PetroleumModel>>(jsonObject["response"].ToString());

                return result.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
           
        }
    }
}

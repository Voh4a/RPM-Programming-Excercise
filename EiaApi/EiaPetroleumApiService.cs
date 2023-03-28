using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RPM_Programming_Excercise.Common;
using RPM_Programming_Excercise.Common.Extensions;
using RPM_Programming_Excercise.EiaApi.Models.RequestModel;
using RPM_Programming_Excercise.EiaApi.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.EiaApi
{
    public class EiaPetroleumApiService : IEiaPetroleumApiService
    {
        private const string apiKey = "EthXWE6eUTrBEJ1uTpNCqbL4NjghRxaC2R5tw1b2";
        private const string petroleumApiUri = "v2/petroleum/pri/gnd/data";
        private readonly IHttpClientFactory _httpClientFactory;

        public EiaPetroleumApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task GeteData()
        {
            //var requestModel = new PetroleumGetRequestModel
            //{
            //    Frequency = "weekly",
            //    Data = new List<string> { "value" },
            //    Facets = new Dictionary<string, List<string>> { { "series", new List<string> { "EMD_EPD2D_PTE_NUS_DPG" } } },
            //    Sort = new List<SortModel> { new SortModel { Column = "period", Direction = "desc" } },
            //    Offset = 0,
            //    Length = 5000
            //};

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

            var httpResponse = await httpClient.GetWithQueryStringAsync(petroleumApiUri, parameters);

            if (httpResponse.IsSuccessStatusCode)
            {
                var contentStream = await httpResponse.Content.ReadAsStringAsync();

                var jsonObject = JObject.Parse(contentStream);
                var result = JsonConvert.DeserializeObject<BaseResponseModel<PetroleumResponseModel>>(jsonObject["response"].ToString());
            }
        }
    }
}

using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.EiaApi.Models.RequestModel
{
    public class PetroleumGetRequestModel
    {
        public string Frequency { get; set; }

        public List<string> Data { get; set; }

        public Dictionary<string, List<string>> Facets { get; set; }

        public List<SortModel> Sort { get; set; }

        public int Offset { get; set; }

        public int Length { get; set; }

        public Dictionary<string, StringValues> GenerateDictionaryOfParams()
        {
            var result = new Dictionary<string, StringValues>();

            if (!string.IsNullOrEmpty(Frequency))
                result.Add("frequency", Frequency);

            if (Data != null && Data.Any())
                result.Add("data", Data.ToArray());

            if (Data != null && Data.Any())
                result.Add("data", Data.ToArray());



            return result;
        }
    }

    public class SortModel
    {
        public string Column { get; set; }

        public string Direction { get; set; }
    }

    public class FacetModel
    {
        public List<string> Series { get; set; }

        public List<string> Process { get; set; }

        public List<string> Duoarea { get; set; }

        public List<string> Product { get; set; }

        public Dictionary<string, StringValues> GenerateDictionaryOfParams(Dictionary<string, StringValues> parameters)
        {
            if (Series != null && Series.Any())
                parameters.Add("facets[series]", Series.ToArray());

            if (Process != null && Process.Any())
                parameters.Add("facets[process]", Process.ToArray());

            if (Duoarea != null && Duoarea.Any())
                parameters.Add("facets[duoarea]", Duoarea.ToArray());

            return parameters;
        }
    }
}

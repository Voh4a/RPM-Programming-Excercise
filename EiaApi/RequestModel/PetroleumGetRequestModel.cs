using RPM_Programming_Excercise.Common;
using System.Collections.Generic;

namespace RPM_Programming_Excercise.EiaApi.RequestModel
{
    public class PetroleumGetRequestModel : IRequestModel
    {
        // TODO: Change to Enum
        public string Frequency { get; set; }

        public List<string> Data { get; set; }

        public Dictionary<string, List<string>> Facets { get; set; }

        public List<SortModel> Sort { get; set; }

        public int Offset { get; set; }

        public int Length { get; set; }

        public Dictionary<string, string> GenerateDictionaryOfParams()
        {
            // TODO: Implement method to fill the Dictionary<string, string> with params
            return null;
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

        public void GenerateDictionaryOfParams(Dictionary<string, string> parameters)
        {
            // TODO: Implement method to fill the Dictionary<string, string> by params
        }
    }
}

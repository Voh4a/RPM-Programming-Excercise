using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.EiaApi.Models.ResponseModel
{
    [JsonObject(Title = "response")]
    public class BaseResponseModel<T>
    {
        public int Total { get; set; }

        public string DateFormat { get; set; }

        public string Frequency { get; set; }

        public List<T> Data { get; set; }
    }
}

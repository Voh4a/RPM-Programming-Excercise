using System.Collections.Generic;

namespace RPM_Programming_Excercise.Common
{
    public class BaseResponseModel<T>
    {
        public int Total { get; set; }

        public string DateFormat { get; set; }

        public string Frequency { get; set; }

        public List<T> Data { get; set; }
    }

    public class ErrorResponseModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}

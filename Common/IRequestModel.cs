using System.Collections.Generic;

namespace RPM_Programming_Excercise.Common
{
    public interface IRequestModel
    {
        Dictionary<string, string> GenerateDictionaryOfParams();
    }
}

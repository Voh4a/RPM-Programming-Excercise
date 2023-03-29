using RPM_Programming_Excercise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.EiaApi
{
    public interface IEiaPetroleumApiService
    {
        Task<List<PetroleumModel>> GetPetroleumData();
    }
}

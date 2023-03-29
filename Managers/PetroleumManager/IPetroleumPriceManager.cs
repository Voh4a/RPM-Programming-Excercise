using RPM_Programming_Excercise.Models;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Managers.PetroleumManager
{
    public interface IPetroleumPriceManager
    {
        Task InsertIfNotExistsAsync(PetroleumModel model);
    }
}

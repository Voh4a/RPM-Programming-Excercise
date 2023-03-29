using RPM_Programming_Excercise.Models;
using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Repositories.PetroleumPriceRepository
{
    public interface IPetroleumPriceRepository
    {
        Task InsertIfNotExistsAsync(PetroleumModel model);
    }
}

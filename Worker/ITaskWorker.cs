using System.Threading.Tasks;

namespace RPM_Programming_Excercise.Worker
{
    public interface ITaskWorker
    {
        Task RunWorker();
    }
}

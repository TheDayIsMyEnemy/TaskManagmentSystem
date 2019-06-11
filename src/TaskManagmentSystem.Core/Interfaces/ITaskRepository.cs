using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface ITaskRepository : IAsyncRepository<AppTask>
    {
        Task<IEnumerable<AppTask>> List(int page, int pageSize);
    }
}

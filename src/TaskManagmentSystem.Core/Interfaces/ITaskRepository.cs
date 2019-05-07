using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface ITaskRepository : IAsyncRepository<AppTask>
    {
    }
}

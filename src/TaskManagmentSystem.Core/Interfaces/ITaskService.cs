using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.DTOs;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetByIdAsync(int id);
    }
}

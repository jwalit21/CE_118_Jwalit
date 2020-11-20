using System;
using System.Collections.Generic;
using System.Linq;

namespace Aarogyam.Models.IRepositories
{
    public interface ITaskRepository
    {
        Task Add(Task task);
        Task GetTask(int TaskID);
        IEnumerable<Task> GetAllTasks();
        Task Update(Task taskChanges);
        Task Delete(int TaskID);
    }
}

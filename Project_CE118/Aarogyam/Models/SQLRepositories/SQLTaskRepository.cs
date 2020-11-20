using Aarogyam.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aarogyam.Models.SQLRepositories
{
    public class SQLTaskrepository: ITaskRepository
    {
        private readonly AppDbContext context;

        public SQLTaskrepository(AppDbContext context)
        {
            this.context = context;
        }

        Task ITaskRepository.Add(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
            return task;
        }

        Task ITaskRepository.Delete(int TaskID)
        {
            Task task = context.Tasks.Find(TaskID);
            if (task != null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
            return task;
        }

        IEnumerable<Task> ITaskRepository.GetAllTasks()
        {
            return context.Tasks;
        }

        Task ITaskRepository.GetTask(int TaskID)
        {
            return context.Tasks.FirstOrDefault(m => m.TaskId == TaskID);
        }

        Task ITaskRepository.Update(Task taskChanges)
        {
            var task = context.Tasks.Attach(taskChanges);
            task.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return taskChanges;
        }
    }
}

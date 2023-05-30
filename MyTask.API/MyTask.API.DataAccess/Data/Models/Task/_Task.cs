using MyTask.API.DataAccess.Data.Enums;

namespace MyTask.API.DataAccess.Data.Models.Task;

public class _Task : ITask
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }
}
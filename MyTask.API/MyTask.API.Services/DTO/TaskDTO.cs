using MyTask.API.DataAccess.Data.Enums;

namespace MyTask.API.Services.DTO;

public class TaskDTO
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskState State { get; set; }
}
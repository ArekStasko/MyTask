using System.ComponentModel.DataAnnotations;
using MyTask.API.DataAccess.Data.Enums;

namespace MyTask.API.DataAccess.Data.Models.Task;

public interface ITask
{
    [Key]
    int Id { get; set; }
    string UserId { get; set; }
    int ProjectId { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    TaskState State { get; set; }
}
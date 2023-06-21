namespace MyTask.API.DataAccess.Data.Models.Project;

public class Project : IProject
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
}
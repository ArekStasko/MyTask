namespace MyTask.API.DataAccess.Data.Models.Raport;

public class Raport : IRaport
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int OpenTasks { get; set; }
    public int InProgressTasks { get; set; }
    public int DoneTasks { get; set; }
}
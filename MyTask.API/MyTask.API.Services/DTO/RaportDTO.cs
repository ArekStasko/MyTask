namespace MyTask.API.Services.DTO;

public class RaportDTO
{
    public int Id { get; set; }
    public string RaportName { get; set; }
    public int OpenTasks { get; set; }
    public int InProgressTasks { get; set; }
    public int DoneTasks { get; set; }
}
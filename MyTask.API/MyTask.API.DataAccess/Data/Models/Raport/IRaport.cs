﻿using System.ComponentModel.DataAnnotations;

namespace MyTask.API.DataAccess.Data.Models.Raport;

public interface IRaport
{
    [Key] 
    int Id { get; set; }
    public string RaportName { get; set; }
    string UserId { get; set; }
    int OpenTasks { get; set; }
    int InProgressTasks { get; set; }
    int DoneTasks { get; set; }
}
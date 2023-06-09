﻿using System.ComponentModel.DataAnnotations;

namespace MyTask.API.DataAccess.Data.Models.Project;

public interface IProject
{
    [Key] 
    int Id { get; set; }
    string UserId { get; set; }
    string Name { get; set; }
}
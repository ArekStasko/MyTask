﻿using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Processors.RaportProcessors.Interfaces;

public interface IGetRaports
{
    Task<List<IRaport>> Execute(string userId);
}
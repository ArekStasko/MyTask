﻿using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.Services.Processors.RaportProcessors.Interfaces;

public interface IGetSingleRaport
{
    Task<IRaport> Execute(int id, string userId);
}
﻿using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.DataAccess.Data.Models.Raport;

namespace MyTask.API.DataAccess.Repositories.RaportRepository;

public class RaportRepository : IRaportRepository
{
    private DataContext _context;
    public RaportRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Generate(IRaport raport, string userId)
    {
        try
        {
            await _context.Raports.AddAsync((Raport)raport);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> Delete(int id, string userId)
    {
        try
        {
            var raport = await _context.Raports.SingleAsync(r => r.Id == id && r.UserId == userId);
            _context.Raports.Remove(raport);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<IRaport>> Get(string userId)
    {
        try
        {
            var raports = await _context.Raports.Where(r => r.UserId == userId).ToListAsync<IRaport>();
            return raports;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IRaport> Get(int id, string userId)
    {
        try
        {
            var raport = await _context.Raports.SingleAsync(r => r.Id == id && r.UserId == userId);
            return raport;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
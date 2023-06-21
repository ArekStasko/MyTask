﻿using Microsoft.EntityFrameworkCore;
using MyTask.API.DataAccess.Data;
using MyTask.API.DataAccess.Data.Models.Project;

namespace MyTask.API.DataAccess.Repositories.ProjectRepository;

public class ProjectRepository : IProjectRepository
{
    private DataContext _context;
    public ProjectRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Create(IProject project, int userId)
    {
        try
        {
            await _context.Projects.AddAsync((Project)project);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> Delete(int id, int userId)
    {
        try
        {
            var project = await _context.Projects.SingleAsync(p => p.Id == id && p.UserId == userId);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<List<IProject>> Get(int userId)
    {
        try
        {
            var projects = await _context.Projects.Where(p => p.UserId == userId).ToListAsync<IProject>();
            return projects;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IProject> Get(int id, int userId)
    {
        try
        {
            var project = await _context.Projects.SingleAsync(p => p.Id == id && p.UserId == userId);
            return project;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
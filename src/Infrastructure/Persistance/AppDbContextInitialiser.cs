﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace practice.Infrastructure.Persistance;

public class AppDbContextInitialiser
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<AppDbContextInitialiser> _logger;

    public AppDbContextInitialiser(AppDbContext dbContext, ILogger<AppDbContextInitialiser> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async System.Threading.Tasks.Task InitializeAsync()
    {
        try
        {
            if (_dbContext.Database.IsSqlServer())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }
}

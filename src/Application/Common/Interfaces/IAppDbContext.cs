﻿using Microsoft.EntityFrameworkCore;
using practice.Domain.Entities;

namespace practice.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Team> Teams { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

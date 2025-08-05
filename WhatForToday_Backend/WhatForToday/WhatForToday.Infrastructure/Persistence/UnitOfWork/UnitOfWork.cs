using WhatForToday.Application.Interfaces.Repositories;
using WhatForToday.Infrastructure.Persistence.DbContexts;

namespace WhatForToday.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangeAsync()
    {
        return await context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
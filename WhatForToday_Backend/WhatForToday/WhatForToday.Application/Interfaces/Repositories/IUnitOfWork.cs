namespace WhatForToday.Application.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangeAsync();
}
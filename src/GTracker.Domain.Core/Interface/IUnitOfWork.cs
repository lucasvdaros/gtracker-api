using System;

namespace GTracker.Domain.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
         bool Commit();
    }
}
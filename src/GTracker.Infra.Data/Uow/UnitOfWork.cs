using System;
using GTracker.Domain.Core.Interface;

namespace GTracker.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GTrackerContext _context;

        public UnitOfWork(GTrackerContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                var changes = _context.SaveChanges();
                return changes > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using RepositoryDP.Model;
using System;
using RepositoryDP.Repository;
using RepositoryDP.DAL;
/// <summary>
/// The Entity Framework implementation of IUnitOfWork
/// </summary>
/// 

namespace RepositoryDP.DAL
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private ApplicationDb _dbContext;

        public UnitOfWork()
        {
        }

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(ApplicationDb context)
        {
            _dbContext = context;
        }

        public IAttachmentsRepository attachments { get; set; }
        public IDepartmentsRepository departments { get; set; }
        public IEmployeesRepository employees { get; set; }
        public IJobsRepository jobs { get; set; }
        public IUnitsRepository units { get; set; }



        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            // Save changes with the default options
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
using RepositoryDP.Repository;
using System;

namespace RepositoryDP.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IAttachmentsRepository attachments { get; set; }
        IDepartmentsRepository departments { get; set; }
        IEmployeesRepository employees { get; set; }
        IJobsRepository jobs { get; set; }
        IUnitsRepository units { get; set; }
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
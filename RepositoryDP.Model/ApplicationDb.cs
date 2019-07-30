using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using RepositoryDP.Model;

namespace RepositoryDP.DAL
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb() : base("Task")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //throw new UnintentionalCodeFirstException();
        //}
        public DbSet<Departments> departments { get; set; }
        public DbSet<Employees> employees { get; set; }
        public DbSet<Jobs> jobs { get; set; }
        public DbSet<Units> units { get; set; }
        public DbSet<EmpDocs> empDocs { get; set; }
        public DbSet<Attachments> docs { get; set; }
        //    public override int SaveChanges()
        //    {
        //        var modifiedEntries = ChangeTracker.Entries()
        //            .Where(x => x.Entity is IAuditableEntity
        //                && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

        //        foreach (var entry in modifiedEntries)
        //        {
        //            IAuditableEntity entity = entry.Entity as IAuditableEntity;
        //            if (entity != null)
        //            {
        //                string identityName = Thread.CurrentPrincipal.Identity.Name;
        //                DateTime now = DateTime.UtcNow;

        //                if (entry.State == System.Data.Entity.EntityState.Added)
        //                {
        //                    entity.CreatedBy = identityName;
        //                    entity.CreatedDate = now;
        //                }
        //                else
        //                {
        //                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //                }

        //                entity.UpdatedBy = identityName;
        //                entity.UpdatedDate = now;
        //            }
        //        }

        //        return base.SaveChanges();
        //    }
    }
}

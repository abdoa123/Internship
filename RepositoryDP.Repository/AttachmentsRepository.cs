using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP.DAL;
using RepositoryDP;
using RepositoryDP.Repository;

namespace RepositoryDP.Repositor
{
    class AttachmentsRepository : IAttachmentsRepository
    {
        IUnitOfWork _unitOfWork;
        private readonly ApplicationDb _context;
        public AttachmentsRepository()
        {
            _context = new ApplicationDb();
        }

        public bool add(Attachments attachment)
        {
            try
            {
                _context.docs.Add(attachment);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool delete(Attachments attachment)
        {
            try
            {
                _context.docs.Remove(attachment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteById(int id)
        {
            try
            {
                Attachments attachment = _context.docs.Find(id);
                if (attachment != null)
                {
                    _context.docs.Remove(attachment);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<Attachments> getAll()
        {
            return _context.docs.ToList();
        }

        public Attachments getById(int attachmentId)
        {
            return _context.docs.Find(attachmentId);
        }

        public IEnumerable<Attachments> getData()
        {
            return _context.docs.ToList();
        }
    }
}

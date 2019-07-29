using RepositoryDP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDP.Repository
{
    public interface IAttachmentsRepository
    {
        IEnumerable<Attachments> getData();
        IEnumerable<Attachments> getAll();
        Attachments getById(int attachmentId);
        bool add(Attachments attachment);
        bool delete(Attachments attachment);
        bool deleteById(int id);
    }
}

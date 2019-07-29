using RepositoryDP.Model;
using System.Collections.Generic;

namespace RepositoryDP.Service
{
    public interface IAttachmentsService
    {

        IEnumerable<Attachments> getData();
        string UploadFile();
    }
}

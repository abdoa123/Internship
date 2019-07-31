using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDP.Model;
using RepositoryDP.Repository;
using System.IO;
using System.Web;
using RepositoryDP.DAL;
using System.Web.Hosting;
using System.Net;

namespace RepositoryDP.Service
{
    public class AttachmentsService : IAttachmentsService
    {
        IUnitOfWork _unitOfWork;
        IAttachmentsRepository _attachmentsRepository;

        public AttachmentsService(IUnitOfWork unitOfWork, IAttachmentsRepository attachmentsRepository)
        {
            _unitOfWork = unitOfWork;
            _attachmentsRepository = attachmentsRepository;
        }

        public IEnumerable<Attachments> getData()
        {
            return _attachmentsRepository.getData();
        }

        public string UploadFile()
        {
            throw new NotImplementedException();
        }

    }
}

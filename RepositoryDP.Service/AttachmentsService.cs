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
    class AttachmentsService : IAttachmentsService
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

        /*        public string UploadFile(string [] files)
                {
                    var empId = 0;
                    var docId = 0;
                    try
                    {
                        foreach (string file in Request.Files)
                        {
                            string[] ids = file.Split(',');
                            int index = ids[0].IndexOf("=") + 1;
                            string id = ids[0].Substring(index);
                            empId = Int32.Parse(ids[0].Substring(index));
                            docId = Int32.Parse(ids[1].Substring(index));
                            var fileContent = Request.Files[file];
                            if (fileContent != null && fileContent.ContentLength > 0)
                            {
                                // get a stream
                                var stream = fileContent.InputStream;
                                // and optionally write the file to disk
                                fileName = fileContent.FileName;
                                string[] paths = fileName.Split('\\');
                                if (paths != null)
                                {
                                    fileName = paths.Last();
                                }
                                fileName = fileName.Replace(" ", String.Empty);
                                //fileName = "empId" + empId + "docId" + docId + ".png";

                                var path = Path.Combine(HostingEnvironment.MapPath("~/Images"), fileName);
                                var finalPath = "../Images/" + fileName;
                                fileName = "";
                                using (var fileStream = System.IO.File.Create(path))
                                {
                                    stream.CopyTo(fileStream);
                                }
                                empDoc.empId = empId;
                                empDoc.docId = docId;
                                empDoc.docPath = finalPath;
                                try
                                {
                                    db.empDocs.Add(empDoc);
                                    message = "Done";
                                }
                                catch (Exception)
                                {
                                    message = "Failed";
                                }



                            }
                        }
                    }
                    catch (Exception)
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        message = "Failed";
                        return Json(message);
                    }
                    finally
                    {
                        db.SaveChanges();
                    }

                    return Json(message);
                }*/
    }
}

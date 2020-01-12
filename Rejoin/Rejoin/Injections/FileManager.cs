using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Rejoin.Data;
using System;
using System.IO;
using System.Linq;

namespace Rejoin.Injections
{
    public interface IFileManager
    {
        string UploadPath { get; }
        string Upload(IFormFile fileç, string allowedTypes = "image/png|image/jpeg|image/gif",
                                   int maxSize = 1024);
    }
    //file manager for uploads
    public class FileManager : IFileManager
    {
        private readonly RejionDBContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IWebHostEnvironment _env;


        public FileManager(RejionDBContext context, IHttpContextAccessor accessor, IWebHostEnvironment env)
        {
            _context = context;
            _accessor = accessor;
            _env = env;
        }

        //path where images will upload
        public string UploadPath
        {
            get
            {
                string UploadPath = Path.Combine(_env.WebRootPath, "images");
                return UploadPath;
            }
        }

        //uploading image
        public string Upload(IFormFile file, string allowedTypes = "image/png|image/jpeg|image/gif",
                                   int maxSize = 1024)
        {
            if (file.Length / 1024 > maxSize)
            {
                throw new Exception("Fayl maksimum 1 mb ola bilər");
            }

            if (!allowedTypes.Split('|').Contains(file.ContentType))
            {
                throw new Exception("Bu tip fayllar qəbul edilmir");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string FilePath = Path.Combine(UploadPath, uniqueFileName);
            file.CopyTo(new FileStream(FilePath, FileMode.Create));

            return uniqueFileName;
        }
    }
}

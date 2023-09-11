using Core.Entities.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string CreateFile(IFormFile formFile)
        {
            if (formFile.Length < 0 && formFile == null)
            {
                throw new Exception("You must upload an image");
            }

            var extension = Path.GetExtension(formFile.FileName);
            var randomFileName = Path.Combine($"{Guid.NewGuid().ToString()}{extension}");
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var path = Path.Combine(directoryPath, randomFileName);

            using (FileStream stream = File.Create(path))
            {
                formFile.CopyTo(stream);
            }

            return path;

        }

        public IResult DeleteFile(string filePath)
        {

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult("You deleted this file successfully");
            }

            return new ErrorResult("Something went wrong");

        }

        public IResult UpdateFile(IFormFile formFile, string filePath)
        {

            if (File.Exists(filePath))
            {
                using (FileStream stream = File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                    return new SuccessResult("You updated this file successfuly");
                }
            }

            return new ErrorResult("Something went wrong");

        }


        public string UseDefaultImage(IFormFile formFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\defaultImage", "abenaki.jpg");

            using (FileStream stream = File.Create(path))
            {
                formFile.CopyTo(stream);
            }

            return path;
        }
    }
}

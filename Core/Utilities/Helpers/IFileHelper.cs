using Core.Entities.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        string CreateFile(IFormFile formFile);
        IResult DeleteFile(string filePath);
        IResult UpdateFile(IFormFile formFile, string filePath);
        string UseDefaultImage(IFormFile formFile);
    }
}

using Microsoft.AspNetCore.Http;
using HumanResource.Framework.Common.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResource.Framework.Common.Service.File
{
    public interface IFileHelper
    {
        Task<bool> DeleteFile(Guid fileId, CancellationToken cancellationToken, string token = null, FileType type = FileType.Image);
        Task<string> GetDocumentUrl(Guid fileId, CancellationToken cancellationToken);
        Task<string> GetImageUrl(Guid fileId, PictureType pictureType, CancellationToken cancellationToken);
        Task<Guid> UploadFile(IFormFile file, CancellationToken cancellationToken, string token = null, FileType type = FileType.Image);
    }
}
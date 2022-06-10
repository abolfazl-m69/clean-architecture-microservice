using Microsoft.AspNetCore.Http;
using HumanResource.Framework.Common.Enums;

namespace HumanResource.Framework.Common.Models.File
{
    public class FileDto
    {
        public IFormFile File { get; set; }
        public FileType FileType { get; set; }
        public long CreatorId { get; set; }
    }
}

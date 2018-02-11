using Microsoft.AspNetCore.Http;

namespace Hexa.Business.Models.Shared
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}

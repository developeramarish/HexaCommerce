using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Hexa.Business.Models.Pictures;
using Hexa.Service.Contracts.Pictures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace HexaCommerce.Api.Admin
{
    public class PictureUploadController : BaseAdminApiController
    {
        private readonly IFileProvider _fileProvider;
        private readonly IPictureService _pictureService;

        public PictureUploadController(IFileProvider fileProvider,
            IPictureService pictureService)
        {
            _fileProvider = fileProvider;
            _pictureService = pictureService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormCollection form)
        {
            if (form == null || form.Files.Count == 0)
                return StatusCode(500, "file(s) not selected");

            var result = 0;
            foreach (var item in form.Files)
            {
                var guidImageName = Guid.NewGuid();
                var extension = Path.GetExtension(item.FileName);
                var fileName = $"{guidImageName.ToString()}{extension}";
                var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Images/Thumbnails",
                        fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                //insert to pictures table
                var pictureModel = new PictureModel
                {
                    Name = fileName,
                    CreatedOn = DateTime.UtcNow
                };

                result = _pictureService.InsertPicture(pictureModel);
            }

            return Ok(result);
        }
    }
}
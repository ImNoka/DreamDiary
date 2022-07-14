using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageProfileController : ControllerBase
    {
        IImageProfileService _service;
        public ImageProfileController(IImageProfileService service)
        {
            _service = service;
        }

        [HttpGet("{guid}")]
        public IActionResult Get(Guid guid)
        {
            ImageProfileDTO imageProfileDTO = _service.Get(guid);
            return File(imageProfileDTO.Image,"image/jpeg");
        }

        [HttpPost]
        public IActionResult Add(Guid profileGuid,IFormFile image)
        {
            if (image == null)
                return Problem("Изображение null");
            long len = image.Length;
            byte[] buffer = new byte[len];
            using (var fileStream = image.OpenReadStream())
            {
                fileStream.Read(buffer, 0, (int)image.Length);
            }

            return Ok(_service.Add(buffer, profileGuid));
            
        }

        [HttpPut]
        public IActionResult Update(Guid guid, IFormFile image)
        {
            if (image == null)
                return Problem("Изображение null");
            long len = image.Length;
            byte[] buffer = new byte[len];
            using (var fileStream = image.OpenReadStream())
            {
                fileStream.Read(buffer, 0, (int)image.Length);
            }
            return Ok(_service.Update(buffer, guid));
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            if (_service.Delete(guid))
                return Ok("Deleted");
            return Problem();
        }

    }
}

using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DreamController : ControllerBase
    {
        IDreamService _service;

        public DreamController(IDreamService service)
        {
            _service = service;
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            return Ok(_service.GetByGuid(guid));
        }

        [HttpGet("{profileGuid}")]
        public IActionResult GetByProfileGuid(Guid profileGuid)
        {
            return Ok(_service.GetByProfileGuid(profileGuid));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var keys = HttpContext.Request.Cookies;
            Guid.TryParse(keys["profileGuid"], out Guid guid);
            return Ok(_service.GetByProfileGuid(guid));
        }

        [HttpPost]
        public IActionResult Add(string name, string text, Guid profileGuid, IFormFile? image)
        {
            long len = image.Length;
            byte[] buffer = new byte[len];
            if (len > 0)
            using (var fileStream = image.OpenReadStream())
            {
                fileStream.Read(buffer, 0, (int)image.Length);
            }
            return Ok(_service.Add(name,text,profileGuid,buffer));
        }

        [HttpPut]
        public IActionResult Update(DreamDTO dreamDTO)
        {
            return Ok(_service.Update(dreamDTO));
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            if (_service.Delete(guid))
                return Ok("Deleted");
            return Problem();
        }
    }
}

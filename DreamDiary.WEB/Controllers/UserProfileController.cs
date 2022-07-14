using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {

        IUserProfileService _service;

        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpPut("")]
        public IActionResult Update(UserProfileDTO profileDTO)
        {
            if (_service.Update(profileDTO) == null)
                return Problem("Профиль null");
            return Ok(_service.Update(profileDTO));
        }


    }
}

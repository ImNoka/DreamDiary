using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IUserProfileService _profileService;

        public UserController(IUserService userService,
                              IUserProfileService profileService)
        {
            _userService = userService;
            _profileService = profileService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPut]
        public IActionResult Update(UserDTO userDTO)
        {
            if (_userService.Update(userDTO) == null)
                return Problem("Пользователь null");
            return Ok(userDTO);
        }

        [HttpPost]
        public IActionResult Register(UserDTO userDTO)
        {
            UserDTO newUserDTO = _userService.Register(userDTO);
            if (newUserDTO != null)
                if (_profileService.Add(newUserDTO.Id) != null)
                    return Ok(userDTO.UserName + " registered");
            return Problem("Failed");
        }

        [HttpDelete]
        public IActionResult Delete(UserProfileDTO profileDTO)
        {
            if (profileDTO == null)
                return Problem("Профиль null");
            _userService.Delete(profileDTO.UserId).Wait();
            _profileService.Delete(profileDTO.Guid).Wait();
            return Ok("Deleted");
        }

    }
}

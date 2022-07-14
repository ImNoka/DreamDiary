using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        INoteProfileService _service;
        public NoteController(INoteProfileService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<NoteProfileDTO> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}

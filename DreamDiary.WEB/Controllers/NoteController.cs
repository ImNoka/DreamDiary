using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        INoteService _service;
        public NoteController(INoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<NoteDTO> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}

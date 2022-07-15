using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteProfileController : ControllerBase
    {
        INoteProfileService _noteService;

        public NoteProfileController(INoteProfileService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var notes = _noteService.GetAll();
            return Ok(notes);
        }

        [HttpGet("{profileGuid}")]
        public IActionResult GetAllByProfileGuid(Guid profileGuid)
        {
            var notes = _noteService.GetAllByProfileGuid(profileGuid);
            return Ok(notes);
        }

        [HttpPost]
        public IActionResult Add(NoteProfileDTO note)
        {
            if (note == null)
                return Problem("Запись null");
            if (_noteService.Add(note).Result)
                return Ok(note);
            return Problem();
        }

        [HttpPut]
        public IActionResult Update(NoteProfileDTO note)
        {
            if (note == null)
                return Problem("Запись null");
            _noteService.Update(note).Wait();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            if (guid == null)
                return Problem("Guid is null");
            if (_noteService.Delete(guid).Result)
                return Ok();
            return Problem();
        }
    }
}

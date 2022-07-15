using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        IGoalService _service;

        public GoalController(IGoalService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetByProfileGuid()
        {
            return Ok();
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(GoalDTO goalDTO)
        {
            return Ok(goalDTO);
        }

        [HttpPut]
        public IActionResult Update(GoalDTO goalDTO)
        {
            return Ok(goalDTO);
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            return Ok();
        }
    }
}

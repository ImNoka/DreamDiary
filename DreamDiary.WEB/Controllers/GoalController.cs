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
    }
}

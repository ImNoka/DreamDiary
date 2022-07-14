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
    }
}

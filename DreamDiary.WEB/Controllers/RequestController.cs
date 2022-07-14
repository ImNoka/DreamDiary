using DreamDiary.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamDiary.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        IRequestService _service;
        public RequestController(IRequestService service)
        {
            _service = service;
        }


    }
}

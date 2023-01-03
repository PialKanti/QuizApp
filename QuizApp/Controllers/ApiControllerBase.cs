using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ApiControllerBase : ControllerBase
    {
    }
}

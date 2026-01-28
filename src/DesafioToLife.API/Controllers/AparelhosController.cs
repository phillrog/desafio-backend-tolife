using DesafioToLife.Domain.Intrerfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioToLife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AparelhosController : ControllerBase
    {
        private IAparelhoService _aparelhoService;

        public AparelhosController(IAparelhoService aparelhoService)
        {
            _aparelhoService = aparelhoService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetListar([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _aparelhoService.Listar(page, pageSize);
            return Ok(result);
        }
    }
}

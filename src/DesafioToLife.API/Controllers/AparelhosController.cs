using DesafioToLife.Application.DTOs;
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

        #region [ GET ]
        
        /// <summary>
        /// Lista todos os aparelhos com planos em ofertas e com paginação.
        /// </summary>
        /// <param name="page">Página atual.</param>
        /// <param name="pageSize">Itens por página.</param>
        [HttpGet("ofertas")]
        [ProducesResponseType(typeof(IEnumerable<AparelhoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOfertas([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _aparelhoService.Ofertas(page, pageSize);
            return Ok(result);
        }

        #endregion
    }
}

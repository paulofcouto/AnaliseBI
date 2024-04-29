using AnaliseBI.Application.Services;
using AnaliseBI.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AnaliseBI.Controllers
{
    [Route("Arquivos")]
    public class SaleController : Controller
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("ProcessFile")]
        public async Task<IActionResult> ProcessFile()
        {
            try
            {
                await _saleService.ProcessFile();
                return Ok("Arquivo processsado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

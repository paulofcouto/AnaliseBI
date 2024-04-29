using AnaliseBI.Application.Services;
using AnaliseBI.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AnaliseBI.Controllers
{
    [Route("Arquivos")]
    public class SaleController : Controller
    {
        private readonly SaleService _saleService;
        public SaleController(SaleService saleService) {
            _saleService = saleService;
        }


        [HttpPost]
        public async Task<IActionResult> ProcessFile()
        {
            await _saleService.ProcessFile();

            return Ok("Ordens adicionadas com sucesso.");
        }
    }
}

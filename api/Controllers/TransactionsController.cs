using api.DTOs.Transaction;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _transactionService.GetAllAsync());
        }

        [Authorize(Roles = "Admin,Worker")]
        [HttpPost("stock-in")]
        public async Task<IActionResult> StockIn(StockInDto dto)
        {
            return Ok(await _transactionService.StockInAsync(dto));
        }

        [Authorize(Roles = "Admin,Worker")]
        [HttpPost("stock-out")]
        public async Task<IActionResult> StockOut(StockOutDto dto)
        {
            return Ok(await _transactionService.StockOutAsync(dto));
        }
    }
}
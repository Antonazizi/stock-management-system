using api.DTOs.Transaction;

namespace api.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionDto> StockInAsync(StockInDto dto);

        Task<TransactionDto> StockOutAsync(StockOutDto dto);

        Task<IEnumerable<TransactionDto>> GetAllAsync();
    }
}
using AnaliseBI.Application.Entities;

namespace AnaliseBI.Infrastructure.Interface
{
    public interface ISaleRepository
    {
        IEnumerable<SaleModel> GetAll();
        Task AddSales(List<SaleModel> tarefa);
        Task DeleteAll();
    }
}
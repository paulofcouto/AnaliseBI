using AnaliseBI.Infrastructure.Interface;
using AnaliseBI.Application.Entities;

namespace AnaliseBI.Infrastructure.MySql
{
    public class SaleRepository : ISaleRepository
    {
        private readonly StageDbContext _context;

        public SaleRepository(StageDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SaleModel> GetAll()
        {
            return _context.Sale.ToList();
        }

        public async Task AddSales(List<SaleModel> sales)
        {
            _context.Sale.AddRange(sales);
            _context.SaveChanges();
        }
    }
}

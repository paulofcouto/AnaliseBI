using AnaliseBI.Infrastructure.Interface;
using AnaliseBI.Application.Entities;
using Microsoft.EntityFrameworkCore.Storage;

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
            return _context.MultiStore.ToList();
        }

        public async Task AddSales(List<SaleModel> sales)
        {
            _context.MultiStore.AddRange(sales);
            _context.SaveChanges();
        }

        public async Task DeleteAll()
        {
            var sales = GetAll();
            _context.MultiStore.RemoveRange(sales);
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}

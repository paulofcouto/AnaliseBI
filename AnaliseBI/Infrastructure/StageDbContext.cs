using AnaliseBI.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnaliseBI.Infrastructure.MySql
{
    public class StageDbContext : DbContext
    {
        public StageDbContext(DbContextOptions<StageDbContext> options) : base(options)
        {

        }

        public DbSet<SaleModel> Sale { get; set; }

    }
}

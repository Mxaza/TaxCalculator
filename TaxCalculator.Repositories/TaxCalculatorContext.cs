using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Models;

namespace TaxCalculator.Repositories
{
    public partial class TaxCalculatorContext : DbContext
    {
        public TaxCalculatorContext(DbContextOptions<TaxCalculatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalculationType> CalculationTypes { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<TaxCalculationResponse> TaxCalculationResults { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TaxCalculatorDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
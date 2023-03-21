using AgendaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeTarefas.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<TarefaModel> TarefaModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

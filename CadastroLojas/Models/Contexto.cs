using Microsoft.EntityFrameworkCore;

namespace CadastroLojas.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<LojasModel> Lojas { get; set; }
    }
}

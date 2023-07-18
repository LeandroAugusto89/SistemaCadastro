using SistemaCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaCadastro.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }
        public DbSet<ContatoModel> Contatos { get; set; }
    }
}

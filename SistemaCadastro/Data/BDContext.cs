using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Models;

namespace SistemaCadastro.Data
{
    public class BDContext : DbContext
    {
        public BDContext (DbContextOptions <BDContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contato { get; set; }
    }
}

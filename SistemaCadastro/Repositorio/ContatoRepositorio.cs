using SistemaCadastro.Data;
using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorio
{

    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BDContext _bdContext;

        public ContatoRepositorio(BDContext bdContext)
        {
            _bdContext = bdContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bdContext.Contato.Add(contato);
            _bdContext.SaveChanges();
            return contato;
        }
    }
}

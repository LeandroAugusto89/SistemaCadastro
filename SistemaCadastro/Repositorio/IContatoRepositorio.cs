using SistemaCadastro.Models;

namespace SistemaCadastro.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}

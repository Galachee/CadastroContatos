using CadastroMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroMVC2.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext bancoContext1; 
        public ContatoRepositorio(BancoContext bancoContext)
        {
            bancoContext1= bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // Salvar no banco de dados
            bancoContext1.Contato.Add(contato);
            bancoContext1.SaveChanges();
            return contato;
        }

        

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new Exception("Ocorreu um erro na atualização do contato");
            
                contatoDb.Nome = contato.Nome;
                contatoDb.Email = contato.Email;
                contatoDb.Celular = contato.Celular;

                bancoContext1.Contato.Update(contatoDb);
                bancoContext1.SaveChanges();
                return contatoDb;
                
            
        }
        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null) throw new Exception("Não foi possivel apagar este contato");

            bancoContext1.Contato.Remove(contatoDb);
            bancoContext1.SaveChanges();
            return true;

        }
        public List<ContatoModel> BuscarTodos()
        {
            return bancoContext1.Contato.ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
            return bancoContext1.Contato.FirstOrDefault(x => x.Id == id);
        }
    }
}

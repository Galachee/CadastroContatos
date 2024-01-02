using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CadastroMVC.Models;
using CadastroMVC2.Repositorio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CadastroMVC.Controllers { 

 
    public class ContatoController : Controller {
        private readonly IContatoRepositorio contatoRepositorio1;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            contatoRepositorio1= contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos=contatoRepositorio1.BuscarTodos();

            return View(contatos);
        }


        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = contatoRepositorio1.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = contatoRepositorio1.ListarPorId(id);

            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try { 
            if(ModelState.IsValid) { 
            contatoRepositorio1.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso!";    
            return RedirectToAction("Index");
            }
            
            return View(contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Algo deu errado no cadastro:{ex.Message}";
                return RedirectToAction("Index");

            }
        }

        public IActionResult Alterar(ContatoModel contato)
        {
            try { 
            if(ModelState.IsValid) { 
            contatoRepositorio1.Atualizar(contato);
                TempData["MensagemAlterar"] = "Contato Alterado com sucesso!";
            return RedirectToAction("Index");
            }
            return View("Editar",contato);
            }
            catch(Exception ex)
            {
                TempData["MensagemErroAlterar"] = $"Não foi possivel alterar seu contato!,{ex.Message}";
                    return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try {
             
            bool apagado = contatoRepositorio1.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemApagar"] = $"Contato foi apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o contato!";
                }
            return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o contato!";

                return RedirectToAction("Index");
            }
        }
    }

}
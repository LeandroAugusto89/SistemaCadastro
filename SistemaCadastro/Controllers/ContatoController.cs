﻿using SistemaCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Repositorio;

namespace SistemaCadastro.Controllers
{

    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                //verifica se está tudo validado
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");

                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado, tente novamente, detalhes do arro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPut]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editato com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado, tente novamente, detalhes do arro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpDelete]
        public IActionResult Apagar(int id)
        {
            try
            {
                if (_contatoRepositorio.Apagar(id))
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, algo deu errado, tente novamente";
                }
                return RedirectToAction("Index");

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado, tente novamente, detalhos do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
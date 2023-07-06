using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCTeste.Context;
using MVCTeste.Models;

namespace MVCTeste.Controllers
{
    public class ContatoController : Controller
    {
        public readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public  IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if(ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null){
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(contato.Id);
            contatoBanco.Name = contato.Name;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
            if(ModelState.IsValid)
            {
                _context.Contatos.Update(contatoBanco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoBanco);
        }
    }
}
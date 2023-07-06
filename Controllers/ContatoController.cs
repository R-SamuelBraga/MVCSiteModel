using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTeste.Context;

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
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTeste.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
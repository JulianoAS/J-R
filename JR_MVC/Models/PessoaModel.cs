using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JR_MVC.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }

    }
}
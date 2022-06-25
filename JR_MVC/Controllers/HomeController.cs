using JR_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jr_repo;

namespace JR_MVC.Controllers
{ 
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EnviarMsg(PessoaModel model)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                Pessoa _pessoa = new Pessoa();
                PessoaBll _pessoabll = new PessoaBll();
                _pessoa.Nome = model.Nome;
                _pessoa.Email = model.Email;
                _pessoa.Mensagem = model.Mensagem;

                model.Id = _pessoabll.Incluir(_pessoa);               
                
               if (_pessoabll.EnviarMsg(_pessoa))
                {
                    return Json("Mensagem enviada!! Em breve entraremos em contato.");
                }

                else
                {
                    return Json("Erro ao enviar MSG!! Email não foi encaminhado.");
                }
              
             }             
        }
    }
}

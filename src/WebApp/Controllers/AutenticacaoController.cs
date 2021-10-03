using Microsoft.AspNetCore.Mvc;
using Pitangueira.Code;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.DTQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class AutenticacaoController : ApplicationController
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastrar(UsuarioSalvarQuery usuarioDTQ)
        {
            if (ModelState.IsValid)
            {
                if (this.GatewayServiceProvider.Get<IUsuarioService>().HasUsuario(usuarioDTQ))
                {
                    ModelState.AddModelError("Username", "Esse username ja esta em uso");

                    return View(usuarioDTQ);
                }


                var usuario = await this.GatewayServiceProvider.Get<IUsuarioService>().Create(usuarioDTQ);
            }

            return RedirectToAction("Index", "Home");

        }


        public ActionResult Login(string ReturnUrl)
        {
            var login = new Login
            {
                UrlRetorno = ReturnUrl
            };

            return View(login);
        }


    }
}

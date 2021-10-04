using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pitangueira.Code;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Model.Entities.DTQ;
using Pitangueira.Model.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

               
                

                TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue login.";
            }

            

            return RedirectToAction("Login");

        }

        public ActionResult Login(string ReturnUrl)
        {
            var login = new Login
            {
                UrlRetorno = ReturnUrl
            };

            return View(login);
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {

                var usuario = await this.GatewayServiceProvider.Get<IUsuarioService>().Login(login);

                if (usuario == null)
                {
                    ModelState.AddModelError("Username", "Login incorreto!");

                    return View(login);
                }

                if (usuario.Senha != Hash.GerarHash(login.Senha))
                {
                    ModelState.AddModelError("Senha", "Senha incorreta!");

                    return View(login);
                }


                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.UserName),
                        new Claim("Login", usuario.Senha),
                    };

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                if (!String.IsNullOrWhiteSpace(login.UrlRetorno) || Url.IsLocalUrl(login.UrlRetorno))
                    return Redirect(login.UrlRetorno);
                else
                    return RedirectToAction("Index", "Atendimentos");

            }

            return RedirectToAction("Index", "Home");

        }

        
        public ActionResult Logout()
        {
             HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

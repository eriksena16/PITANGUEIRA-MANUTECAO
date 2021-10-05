using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pitangueira.Code;
using Pitangueira.Contract.AtendimentoContract;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Authorize]
    public class AtendimentosController : ApplicationController
    {

        [Authorize]
        public ActionResult Index()
        {
            List<Atendimento_> atendimentos = this.GatewayServiceProvider.Get<IAtendimentoService>().GetAll();

            return View(atendimentos);
        }


        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Atendimento_ atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().Details(id);

            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        public IActionResult Create()
        {

            DropdownListCliente();
            DropdownListTipoDeAtendimento();
            DropdownListUsuario();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atendimento_ atendimento)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Tecnico"))
                {
                    var userName = User.Identity.Name;

                    var usuarios = this.GatewayServiceProvider.Get<IAtendimentoService>().GetUsuario();

                    foreach (var obj in usuarios)
                    {
                        if (userName == obj.UserName)
                        {
                            atendimento.UsuarioId = obj.Id;
                        }
                    }
                }
               

                atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().Create(atendimento);

                return RedirectToAction(nameof(Index));
            }
            DropdownListCliente(atendimento.ClienteId);
            DropdownListTipoDeAtendimento(atendimento.TipoAtendimentoId);
            DropdownListUsuario(atendimento.UsuarioId);
            
            return View(atendimento);
        }
        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Tecnico"))
            {
                ViewBag.Mensagem = "Usuario com perfil de Tecnico não pode realizar Alterações";

            }

            var atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().GetUpdate(id.Value);

            if (atendimento == null)
            {
                return NotFound();
            }
            DropdownListCliente(atendimento.ClienteId);
            DropdownListTipoDeAtendimento(atendimento.TipoAtendimentoId);
            DropdownListUsuario(atendimento.UsuarioId);
            return View(atendimento);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Atendimento_ atendimento)
        {
            if (id != atendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.GatewayServiceProvider.Get<IAtendimentoService>().Update(id, atendimento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            
            DropdownListCliente(atendimento.ClienteId);
            DropdownListTipoDeAtendimento(atendimento.TipoAtendimentoId);
            DropdownListUsuario(atendimento.UsuarioId);
            return View(atendimento);
        }

        [Authorize(Roles = "Gestor")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().Delete(id.Value);

            if (atendimento == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Tecnico"))
            {
                ViewBag.Mensagem = "Usuario com perfil de Tecnico não apagar registros da tela de atendimento";

            }

            return View(atendimento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }


        private bool AtendimentoExists(long id)
        {
            return this.GatewayServiceProvider.Get<IAtendimentoService>().Exists(id);
        }

        private void DropdownListCliente(object listaCliente = null)
        {
            var lista = this.GatewayServiceProvider.Get<IAtendimentoService>().DropdownListCliente();

            ViewBag.ClienteId = new SelectList(lista, "Id", "Name", listaCliente);
        }

        private void DropdownListTipoDeAtendimento(object tipoDeAtendimento = null)
        {
            var lista = this.GatewayServiceProvider.Get<IAtendimentoService>().DropdownListTipoDeAtendimento();

            ViewBag.TipoAtendimentoId = new SelectList(lista, "Id", "Name", tipoDeAtendimento);
        }

        private void DropdownListUsuario(object listaUsuario = null)
        {
            var lista = this.GatewayServiceProvider.Get<IAtendimentoService>().GetUsuario();

            ViewBag.UsuarioId = new SelectList(lista, "Id", "Nome", listaUsuario);
        }
    }
}

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
    
    public class AtendimentosController : ApplicationController
    {
        private readonly PitangaDbContext _context;

        public AtendimentosController(PitangaDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Atendimento_> atendimentos =  this.GatewayServiceProvider.Get<IAtendimentoService>().GetAll();

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
            return View();
        }

        [Authorize]
        public ActionResult Mensagens()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Atendimento_ atendimento)
        {
            if (ModelState.IsValid)
            {
                //atendimento.UsuarioId = this.Usuario.FindFirstValue(ClaimTypes.NameIdentifier);

                atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().Create(atendimento);

                return RedirectToAction(nameof(Index));
            }
            DropdownListCliente(atendimento.ClienteId);
            //ViewData["UsuarioId"] = new SelectList(_context.Tecnico, "Id", "Id", atendimento.UsuarioId);
            return View(atendimento);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().GetUpdate(id.Value);

            if (atendimento == null)
            {
                return NotFound();
            }
            DropdownListCliente(atendimento.ClienteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", atendimento.UsuarioId);
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

            //ViewData["UsuarioId"] = this.Usuario.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(atendimento);
        }

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
            return _context.Atendimento.Any(e => e.Id == id);
        }

        private void DropdownListCliente(object listaCliente = null)
        {
            var lista = this.GatewayServiceProvider.Get<IAtendimentoService>().DropdownListCliente();

            ViewBag.ClienteId = new SelectList(lista, "Id", "Name", listaCliente);
        }
    }
}

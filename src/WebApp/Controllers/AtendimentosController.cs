using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pitangueira.Code;
using Pitangueira.Model.Entities;
using Pitangueira.Repository.AtendimentoRepository;
using System.Security.Claims;
using Pitangueira.Contract.AtendimentoContract;

namespace WebApp.Controllers
{
    public class AtendimentosController : ApplicationController
    {
        private readonly PitangaDbContext _context;

        public AtendimentosController(PitangaDbContext context)
        {
            _context = context;
        }

        // GET: Atendimentos
        public async Task<IActionResult> Index()
        {
            List<Atendimento> atendimentos =  this.GatewayServiceProvider.Get<IAtendimentoService>().GetAll();

            return View(atendimentos);
        }

        // GET: Atendimentos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Atendimento atendimento = await this.GatewayServiceProvider.Get<IAtendimentoService>().Details(id);

            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public IActionResult Create()
        {
            DropdownListCliente();
            return View();
        }

        // POST: Atendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Atendimento atendimento)
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

        // GET: Atendimentos/Edit/5
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

        // POST: Atendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Atendimento atendimento)
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

        // GET: Atendimentos/Delete/5
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

        // POST: Atendimentos/Delete/5
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

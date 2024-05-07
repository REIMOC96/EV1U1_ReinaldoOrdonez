using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercydevs.Models;

namespace Mercydevs.Controllers
{
    public class ClienteserviciosController : Controller
    {
        private readonly MercydevsContext _context;

        public ClienteserviciosController(MercydevsContext context)
        {
            _context = context;
        }

        // GET: Clienteservicios
        public async Task<IActionResult> Index()
        {
            var mercydevsContext = _context.Clienteservicios.Include(c => c.ClientesIdclientesNavigation).Include(c => c.ServicioIdservicioNavigation);
            return View(await mercydevsContext.ToListAsync());
        }

        // GET: Clienteservicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteservicio = await _context.Clienteservicios
                .Include(c => c.ClientesIdclientesNavigation)
                .Include(c => c.ServicioIdservicioNavigation)
                .FirstOrDefaultAsync(m => m.IdClienteServicio == id);
            if (clienteservicio == null)
            {
                return NotFound();
            }

            return View(clienteservicio);
        }

        // GET: Clienteservicios/Create
        public IActionResult Create()
        {
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes");
            ViewData["ServicioIdservicio"] = new SelectList(_context.Servicios, "Idservicio", "Idservicio");
            return View();
        }

        // POST: Clienteservicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClienteServicio,ClientesIdclientes,ServicioIdservicio")] Clienteservicio clienteservicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteservicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clienteservicio.ClientesIdclientes);
            ViewData["ServicioIdservicio"] = new SelectList(_context.Servicios, "Idservicio", "Idservicio", clienteservicio.ServicioIdservicio);
            return View(clienteservicio);
        }

        // GET: Clienteservicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteservicio = await _context.Clienteservicios.FindAsync(id);
            if (clienteservicio == null)
            {
                return NotFound();
            }
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clienteservicio.ClientesIdclientes);
            ViewData["ServicioIdservicio"] = new SelectList(_context.Servicios, "Idservicio", "Idservicio", clienteservicio.ServicioIdservicio);
            return View(clienteservicio);
        }

        // POST: Clienteservicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClienteServicio,ClientesIdclientes,ServicioIdservicio")] Clienteservicio clienteservicio)
        {
            if (id != clienteservicio.IdClienteServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteservicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteservicioExists(clienteservicio.IdClienteServicio))
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
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clienteservicio.ClientesIdclientes);
            ViewData["ServicioIdservicio"] = new SelectList(_context.Servicios, "Idservicio", "Idservicio", clienteservicio.ServicioIdservicio);
            return View(clienteservicio);
        }

        // GET: Clienteservicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteservicio = await _context.Clienteservicios
                .Include(c => c.ClientesIdclientesNavigation)
                .Include(c => c.ServicioIdservicioNavigation)
                .FirstOrDefaultAsync(m => m.IdClienteServicio == id);
            if (clienteservicio == null)
            {
                return NotFound();
            }

            return View(clienteservicio);
        }

        // POST: Clienteservicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteservicio = await _context.Clienteservicios.FindAsync(id);
            if (clienteservicio != null)
            {
                _context.Clienteservicios.Remove(clienteservicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteservicioExists(int id)
        {
            return _context.Clienteservicios.Any(e => e.IdClienteServicio == id);
        }
    }
}

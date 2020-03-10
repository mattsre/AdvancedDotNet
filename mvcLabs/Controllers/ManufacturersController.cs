using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcLabs.Models;

namespace mvcLabs.Controllers
{
  public class ManufacturersController : Controller
  {
    private readonly CarContext _context;

    public ManufacturersController(CarContext context)
    {
      _context = context;
    }

    // GET: Manufacturer
    public async Task<IActionResult> Index()
    {
      return View(await _context.Manufacturers.ToListAsync());
    }

    // GET: Manufacturer/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var manufacturer = await _context.Manufacturers
          .FirstOrDefaultAsync(m => m.ID == id);
      if (manufacturer == null)
      {
        return NotFound();
      }

      return View(manufacturer);
    }

    // GET: Manufacturer/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Manufacturer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Make")] Manufacturer manufacturer)
    {
      if (ModelState.IsValid)
      {
        _context.Add(manufacturer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(manufacturer);
    }

    // GET: Manufacturer/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var manufacturer = await _context.Manufacturers.FindAsync(id);
      if (manufacturer == null)
      {
        return NotFound();
      }
      return View(manufacturer);
    }

    // POST: Manufacturer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Make")] Manufacturer manufacturer)
    {
      if (id != manufacturer.ID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(manufacturer);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ManufacturerExists(manufacturer.ID))
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
      return View(manufacturer);
    }

    // GET: Manufacturer/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var manufacturer = await _context.Manufacturers
          .FirstOrDefaultAsync(m => m.ID == id);
      if (manufacturer == null)
      {
        return NotFound();
      }

      return View(manufacturer);
    }

    // POST: Manufacturer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var manufacturer = await _context.Manufacturers.FindAsync(id);
      _context.Manufacturers.Remove(manufacturer);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ManufacturerExists(int id)
    {
      return _context.Manufacturers.Any(e => e.ID == id);
    }
  }
}

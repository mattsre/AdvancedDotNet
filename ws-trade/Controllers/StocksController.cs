using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLab1.Models;

namespace MVCLab1.Controllers
{
    public class StocksController : Controller
    {
        private readonly TradingContext _context;

        public StocksController(TradingContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var stocks = await _context.Stocks.ToListAsync();
            var user = await _context.Accounts.FirstAsync();
            var model = new StockViewModel(user, stocks); 
            return View(model);
        }

        // GET: Stocks/Buy/:id
        public async Task<IActionResult> Buy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.Stocks
                .FirstOrDefaultAsync(m => m.ID == id);
            var user = await _context.Accounts.FirstAsync();
            if (stockModel == null)
            {
                return NotFound();
            }
            user.Balance = Math.Round(user.Balance - stockModel.Price);
            stockModel.Price += Math.Round((new Random().NextDouble()) * (100 - -100) + -100);
            _context.Stocks.Update(stockModel);
            _context.Accounts.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Stocks/Sell/:id
        public async Task<IActionResult> Sell(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.Stocks
                .FirstOrDefaultAsync(m => m.ID == id);
            var user = await _context.Accounts.FirstAsync();
            if (stockModel == null)
            {
                return NotFound();
            }
            user.Balance = Math.Round(user.Balance + stockModel.Price);
            stockModel.Price += Math.Round((new Random().NextDouble()) * (100 - -100) + -100);
            _context.Stocks.Update(stockModel);
            _context.Accounts.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.Stocks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return View(stockModel);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ticker,StockName,Price")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockModel);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.Stocks.FindAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
            return View(stockModel);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ticker,StockName,Price")] StockModel stockModel)
        {
            if (id != stockModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockModelExists(stockModel.ID))
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
            return View(stockModel);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.Stocks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return View(stockModel);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockModel = await _context.Stocks.FindAsync(id);
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockModelExists(int id)
        {
            return _context.Stocks.Any(e => e.ID == id);
        }
    }
}

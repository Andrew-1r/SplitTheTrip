using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SplitTheTrip.Data;
using SplitTheTrip.Models;

namespace SplitTheTrip.Controllers
{
    public class TotalExpenseController : Controller
    {
        private readonly SplitTheTripContext _context;

        public TotalExpenseController(SplitTheTripContext context)
        {
            _context = context;
        }

        // GET: TotalExpense
        public async Task<IActionResult> Index()
        {
            var splitTheTripContext = _context.TotalExpenses.Include(t => t.Group).Include(t => t.Payer);
            return View(await splitTheTripContext.ToListAsync());
        }

        // GET: TotalExpense/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalExpense = await _context.TotalExpenses
                .Include(t => t.Group)
                .Include(t => t.Payer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalExpense == null)
            {
                return NotFound();
            }

            return View(totalExpense);
        }

        // GET: TotalExpense/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name");
            ViewData["PayerId"] = new SelectList(_context.Set<GroupMember>(), "Id", "Name");
            return View();
        }

        // POST: TotalExpense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,PayerId,Name,TotalAmount,CreatedAt,IsDeleted")] TotalExpense totalExpense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(totalExpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name", totalExpense.GroupId);
            ViewData["PayerId"] = new SelectList(_context.Set<GroupMember>(), "Id", "Name", totalExpense.PayerId);
            return View(totalExpense);
        }

        // GET: TotalExpense/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalExpense = await _context.TotalExpenses.FindAsync(id);
            if (totalExpense == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name", totalExpense.GroupId);
            ViewData["PayerId"] = new SelectList(_context.Set<GroupMember>(), "Id", "Name", totalExpense.PayerId);
            return View(totalExpense);
        }

        // POST: TotalExpense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,PayerId,Name,TotalAmount,CreatedAt,IsDeleted")] TotalExpense totalExpense)
        {
            if (id != totalExpense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(totalExpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalExpenseExists(totalExpense.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Set<Group>(), "Id", "Name", totalExpense.GroupId);
            ViewData["PayerId"] = new SelectList(_context.Set<GroupMember>(), "Id", "Name", totalExpense.PayerId);
            return View(totalExpense);
        }

        // GET: TotalExpense/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var totalExpense = await _context.TotalExpenses
                .Include(t => t.Group)
                .Include(t => t.Payer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (totalExpense == null)
            {
                return NotFound();
            }

            return View(totalExpense);
        }

        // POST: TotalExpense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var totalExpense = await _context.TotalExpenses.FindAsync(id);
            if (totalExpense != null)
            {
                _context.TotalExpenses.Remove(totalExpense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalExpenseExists(int id)
        {
            return _context.TotalExpenses.Any(e => e.Id == id);
        }
    }
}

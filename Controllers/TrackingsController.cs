using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using World_Wide_Parcel.Data;
using World_Wide_Parcel.Models;

namespace World_Wide_Parcel.Controllers
{
    public class TrackingsController : Controller
    {
        private readonly World_Wide_ParcelDatabase _context;

        public TrackingsController(World_Wide_ParcelDatabase context)
        {
            _context = context;
        }

        // GET: Trackings
        public async Task<IActionResult> Index()
        {
            var world_Wide_ParcelDatabase = _context.Tracking.Include(t => t.Parcels);
            return View(await world_Wide_ParcelDatabase.ToListAsync());
        }

        // GET: Trackings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracking = await _context.Tracking
                .Include(t => t.Parcels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tracking == null)
            {
                return NotFound();
            }

            return View(tracking);
        }

        // GET: Trackings/Create
        public IActionResult Create()
        {
            ViewData["ParcelsId"] = new SelectList(_context.Set<Parcels>(), "Id", "Content_type");
            return View();
        }

        // POST: Trackings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Expected_date_of_delivery,ParcelsId")] Tracking tracking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tracking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParcelsId"] = new SelectList(_context.Set<Parcels>(), "Id", "Content_type", tracking.ParcelsId);
            return View(tracking);
        }

        // GET: Trackings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracking = await _context.Tracking.FindAsync(id);
            if (tracking == null)
            {
                return NotFound();
            }
            ViewData["ParcelsId"] = new SelectList(_context.Set<Parcels>(), "Id", "Content_type", tracking.ParcelsId);
            return View(tracking);
        }

        // POST: Trackings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Expected_date_of_delivery,ParcelsId")] Tracking tracking)
        {
            if (id != tracking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tracking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackingExists(tracking.Id))
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
            ViewData["ParcelsId"] = new SelectList(_context.Set<Parcels>(), "Id", "Content_type", tracking.ParcelsId);
            return View(tracking);
        }

        // GET: Trackings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracking = await _context.Tracking
                .Include(t => t.Parcels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tracking == null)
            {
                return NotFound();
            }

            return View(tracking);
        }

        // POST: Trackings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tracking = await _context.Tracking.FindAsync(id);
            _context.Tracking.Remove(tracking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackingExists(int id)
        {
            return _context.Tracking.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Models;

namespace VotingSystem.Controllers
{
    public class CandidatePositionsController : Controller
    {
        private readonly VotingDBContext _context;

        public CandidatePositionsController(VotingDBContext context)
        {
            _context = context;
        }

        // GET: CandidatePositions
        public async Task<IActionResult> Index()
        {
            var votingDBContext = _context.CandidatePosition.Include(c => c.Candidate).Include(c => c.Position);
            return View(await votingDBContext.ToListAsync());
        }

        // GET: CandidatePositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatePosition = await _context.CandidatePosition
                .Include(c => c.Candidate)
                .Include(c => c.Position)
                .FirstOrDefaultAsync(m => m.id == id);
            if (candidatePosition == null)
            {
                return NotFound();
            }

            return View(candidatePosition);
        }

        // GET: CandidatePositions/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "candidateId", "name");
            ViewData["PositionId"] = new SelectList(_context.Position, "positionId", "PositionName");
            return View();
        }

        // POST: CandidatePositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,CandidateId,PositionId")] CandidatePosition candidatePosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatePosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "candidateId", "candidateId", candidatePosition.CandidateId);
            ViewData["PositionId"] = new SelectList(_context.Position, "positionId", "positionId", candidatePosition.PositionId);
            return View(candidatePosition);
        }

        // GET: CandidatePositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatePosition = await _context.CandidatePosition.FindAsync(id);
            if (candidatePosition == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "candidateId", "name", candidatePosition.CandidateId);
            ViewData["PositionId"] = new SelectList(_context.Position, "positionId", "PositionName", candidatePosition.PositionId);
            return View(candidatePosition);
        }

        // POST: CandidatePositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,CandidateId,PositionId")] CandidatePosition candidatePosition)
        {
            if (id != candidatePosition.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatePosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatePositionExists(candidatePosition.id))
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
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "candidateId", "name", candidatePosition.CandidateId);
            ViewData["PositionId"] = new SelectList(_context.Position, "positionId", "PositionName", candidatePosition.PositionId);
            return View(candidatePosition);
        }

        // GET: CandidatePositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatePosition = await _context.CandidatePosition
                .Include(c => c.Candidate)
                .Include(c => c.Position)
                .FirstOrDefaultAsync(m => m.id == id);
            if (candidatePosition == null)
            {
                return NotFound();
            }

            return View(candidatePosition);
        }

        // POST: CandidatePositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatePosition = await _context.CandidatePosition.FindAsync(id);
            _context.CandidatePosition.Remove(candidatePosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatePositionExists(int id)
        {
            return _context.CandidatePosition.Any(e => e.id == id);
        }
    }
}

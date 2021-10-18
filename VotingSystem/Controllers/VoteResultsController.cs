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
    public class VoteResultsController : Controller
    {
        private readonly VotingDBContext _context;

        public VoteResultsController(VotingDBContext context)
        {
            _context = context;
        }

        // GET: VoteResults
        public async Task<IActionResult> Index()
        {
            var votingDBContext = _context.VoteResult.Include(v => v.Candidate).Include(v => v.Position).Include(v => v.Voter);
            return View(await votingDBContext.ToListAsync());
        }

        // GET: VoteResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voteResult = await _context.VoteResult
                .Include(v => v.Candidate)
                .Include(v => v.Position)
                .Include(v => v.Voter)
                .FirstOrDefaultAsync(m => m.id == id);
            if (voteResult == null)
            {
                return NotFound();
            }

            return View(voteResult);
        }

        // GET: VoteResults/Create
        public IActionResult Create()
        {
            ViewData["candidateId"] = new SelectList(_context.Candidate, "candidateId", "candidateId");
            ViewData["positionId"] = new SelectList(_context.Position, "positionId", "positionId");
            ViewData["voterId"] = new SelectList(_context.Voter, "idNo", "idNo");
            return View();
        }

        // POST: VoteResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,voterId,candidateId,positionId")] VoteResult voteResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voteResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["candidateId"] = new SelectList(_context.Candidate, "candidateId", "candidateId", voteResult.candidateId);
            ViewData["positionId"] = new SelectList(_context.Position, "positionId", "positionId", voteResult.positionId);
            ViewData["voterId"] = new SelectList(_context.Voter, "idNo", "idNo", voteResult.voterId);
            return View(voteResult);
        }

        // GET: VoteResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voteResult = await _context.VoteResult.FindAsync(id);
            if (voteResult == null)
            {
                return NotFound();
            }
            ViewData["candidateId"] = new SelectList(_context.Candidate, "candidateId", "candidateId", voteResult.candidateId);
            ViewData["positionId"] = new SelectList(_context.Position, "positionId", "positionId", voteResult.positionId);
            ViewData["voterId"] = new SelectList(_context.Voter, "idNo", "idNo", voteResult.voterId);
            return View(voteResult);
        }

        // POST: VoteResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,voterId,candidateId,positionId")] VoteResult voteResult)
        {
            if (id != voteResult.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voteResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteResultExists(voteResult.id))
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
            ViewData["candidateId"] = new SelectList(_context.Candidate, "candidateId", "candidateId", voteResult.candidateId);
            ViewData["positionId"] = new SelectList(_context.Position, "positionId", "positionId", voteResult.positionId);
            ViewData["voterId"] = new SelectList(_context.Voter, "idNo", "idNo", voteResult.voterId);
            return View(voteResult);
        }

        // GET: VoteResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voteResult = await _context.VoteResult
                .Include(v => v.Candidate)
                .Include(v => v.Position)
                .Include(v => v.Voter)
                .FirstOrDefaultAsync(m => m.id == id);
            if (voteResult == null)
            {
                return NotFound();
            }

            return View(voteResult);
        }

        // POST: VoteResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voteResult = await _context.VoteResult.FindAsync(id);
            _context.VoteResult.Remove(voteResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteResultExists(int id)
        {
            return _context.VoteResult.Any(e => e.id == id);
        }
    }
}

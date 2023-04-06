using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testing.EFCore.MVC.Model;

namespace Testing.EFCore.MVC.Controllers
{
    public class TMoviesController : Controller
    {
        private readonly InseparableContext _context;

        public TMoviesController(InseparableContext context)
        {
            _context = context;
        }

        // GET: TMovies
        public async Task<IActionResult> Index()
        {
            var inseparableContext = _context.TMovies.Include(t => t.FMovieLevel);
            return View(await inseparableContext.ToListAsync());
        }

        // GET: TMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TMovies == null)
            {
                return NotFound();
            }

            var tMovie = await _context.TMovies
                .Include(t => t.FMovieLevel)
                .FirstOrDefaultAsync(m => m.FMovieId == id);
            if (tMovie == null)
            {
                return NotFound();
            }

            return View(tMovie);
        }

        // GET: TMovies/Create
        public IActionResult Create()
        {
            ViewData["FMovieLevelId"] = new SelectList(_context.TMovieLevels, "FLevelId", "FLevelId");
            return View();
        }

        // POST: TMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FMovieId,FMovieName,FMovieIntroduction,FMovieLevelId,FMovieOnDate,FMovieOffDate,FMovieLength,FMovieImagePath,FMovieScore")] TMovie tMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FMovieLevelId"] = new SelectList(_context.TMovieLevels, "FLevelId", "FLevelId", tMovie.FMovieLevelId);
            return View(tMovie);
        }

        // GET: TMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TMovies == null)
            {
                return NotFound();
            }

            var tMovie = await _context.TMovies.FindAsync(id);
            if (tMovie == null)
            {
                return NotFound();
            }
            ViewData["FMovieLevelId"] = new SelectList(_context.TMovieLevels, "FLevelId", "FLevelId", tMovie.FMovieLevelId);
            return View(tMovie);
        }

        // POST: TMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FMovieId,FMovieName,FMovieIntroduction,FMovieLevelId,FMovieOnDate,FMovieOffDate,FMovieLength,FMovieImagePath,FMovieScore")] TMovie tMovie)
        {
            if (id != tMovie.FMovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TMovieExists(tMovie.FMovieId))
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
            ViewData["FMovieLevelId"] = new SelectList(_context.TMovieLevels, "FLevelId", "FLevelId", tMovie.FMovieLevelId);
            return View(tMovie);
        }

        // GET: TMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TMovies == null)
            {
                return NotFound();
            }

            var tMovie = await _context.TMovies
                .Include(t => t.FMovieLevel)
                .FirstOrDefaultAsync(m => m.FMovieId == id);
            if (tMovie == null)
            {
                return NotFound();
            }

            return View(tMovie);
        }

        // POST: TMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TMovies == null)
            {
                return Problem("Entity set 'InseparableContext.TMovies'  is null.");
            }
            var tMovie = await _context.TMovies.FindAsync(id);
            if (tMovie != null)
            {
                _context.TMovies.Remove(tMovie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TMovieExists(int id)
        {
          return (_context.TMovies?.Any(e => e.FMovieId == id)).GetValueOrDefault();
        }
    }
}

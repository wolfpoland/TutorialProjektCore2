using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutorialProjektCore.Data;
using TutorialProjektCore.Models;

namespace TutorialProjektCore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Movies
        /*    public async Task<IActionResult> Index(string szukaj)
            {
                var filmy = from m in _context.Movie
                            select m;
                if (!String.IsNullOrEmpty(szukaj))
                {
                    filmy = filmy.Where(s => s.Tytul.Contains(szukaj));
                }
                return View(await filmy.ToListAsync());


            }

            public async Task<IActionResult> Index(string movieGenre, string szukaj)
            {
                IQueryable<string> generQuery = from m in _context.Movie
                                                orderby m.gatunek
                                                select m.gatunek;
                var movies = from m in _context.Movie
                             select m;
                if (!String.IsNullOrEmpty(szukaj))
                {
                    movies = movies.Where(k => k.Tytul.Contains(szukaj));
                }
                if (!String.IsNullOrEmpty(movieGenre))
                {
                    movies = movies.Where(x => x.gatunek == movieGenre);
                }
                var movieGenreVM = new MovieGenreViewModelcs();
                movieGenreVM.genres = new SelectList(await generQuery.Distinct().ToListAsync());
                movieGenreVM.movies = await movies.ToListAsync();
                return View(movieGenreVM);
            }
            */
        public async Task<IActionResult> Index(string movieGenre, string szukaj)
        {
            // Use LINQ to get list of genre's.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.gatunek
                                            select m.gatunek;

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(szukaj))
            {
                movies = movies.Where(s => s.Tytul.Contains(szukaj));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.gatunek == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModelcs();
            movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            movieGenreVM.movies = await movies.ToListAsync();

            return View(movieGenreVM);
        }
        [HttpPost]
        public string Index(string szukaj,bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + szukaj;
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataWydania,Tytul,cena,gatunek")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataWydania,Tytul,cena,gatunek")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}

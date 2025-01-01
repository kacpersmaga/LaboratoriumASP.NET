using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowy.Models.Movies;
using ProjektZaliczeniowy.Models.Paging;
using ProjektZaliczeniowy.Models.ViewModels;

namespace ProjektZaliczeniowy.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesContext _context;

        public MovieController(MoviesContext context)
        {
            _context = context;
        }
        
        public IActionResult ProductionCompanies(int page = 1, int size = 20)
        {
            return View(PagingListAsync<ProductionCompanyViewModel>.Create(
                (p, s) =>
                    _context.ProductionCompanies
                        .OrderBy(c => c.CompanyName)
                        .Skip((p - 1) * s)
                        .Take(s)
                        .Select(company => new ProductionCompanyViewModel
                        {
                            CompanyId = company.CompanyId,
                            CompanyName = company.CompanyName ?? "Unknown Company",
                            MovieCount = _context.MovieCompanies.Count(mc => mc.CompanyId == company.CompanyId),
                            TotalBudget = _context.MovieCompanies
                                .Where(mc => mc.CompanyId == company.CompanyId)
                                .Join(
                                    _context.Movies,
                                    mc => mc.MovieId,
                                    m => m.MovieId,
                                    (mc, m) => m.Budget ?? 0
                                )
                                .Sum()
                        })
                        .AsAsyncEnumerable(),
                _context.ProductionCompanies.Count(),
                page,
                size
            ));
        }
        
        public async Task<IActionResult> MoviesByCompany(int companyId)
        {
            var movies = await _context.MovieCompanies
                .Where(mc => mc.CompanyId == companyId)
                .Join(
                    _context.Movies,
                    mc => mc.MovieId,
                    m => m.MovieId,
                    (mc, m) => new
                    {
                        m.MovieId,
                        m.Title,
                        m.Popularity,
                        m.Revenue,
                        m.Runtime,
                        m.VoteAverage,
                        m.VoteCount
                    }
                )
                .Select(m => new MovieViewModel
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Popularity = m.Popularity,
                    Revenue = m.Revenue,
                    Runtime = m.Runtime,
                    VoteAverage = m.VoteAverage,
                    VoteCount = m.VoteCount
                })
                .ToListAsync();

            var companyName = await _context.ProductionCompanies
                .Where(c => c.CompanyId == companyId)
                .Select(c => c.CompanyName)
                .FirstOrDefaultAsync();

            ViewBag.CompanyName = companyName;
            ViewBag.CompanyId = companyId;

            return View(movies);
        }
        
        public async Task<IActionResult> ManageKeywords(int movieId, int companyId)
        {
            var movie = await _context.Movies
                .Where(m => m.MovieId == movieId)
                .Select(m => new
                {
                    m.Title
                })
                .FirstOrDefaultAsync();

            if (movie == null) return NotFound();
            
            var keywords = await _context.MovieKeywords
                .Where(mk => mk.MovieId == movieId)
                .Join(
                    _context.Keywords,
                    mk => mk.KeywordId,
                    k => k.KeywordId,
                    (mk, k) => k.KeywordName
                )
                .ToListAsync();
            
            var viewModel = new MovieKeywordViewModel
            {
                MovieId = movieId,
                Title = movie.Title,
                Keywords = keywords,
                CompanyId = companyId,
                NewKeyword = string.Empty
            };

            return View(viewModel);
        }
        
    }
}

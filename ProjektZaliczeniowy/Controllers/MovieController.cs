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
        
    }
}

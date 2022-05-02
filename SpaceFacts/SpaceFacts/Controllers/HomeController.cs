using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpaceFacts.Data;
using SpaceFacts.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceFacts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
       
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
         
        }

       

        public async Task<IActionResult> Index()
        {
            return View(await _applicationDbContext.Facts.OrderBy(x => x.Id).ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AddOrEditAsync(int Id)
        {
            if (Id != 0)
            {
                return View(await _applicationDbContext.Facts.Where(x => x.Id == Id).FirstOrDefaultAsync());
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> NewEditFactAsync(Fact fact)
        {
            if (fact.Id == 0)
            {
                await _applicationDbContext.Facts.AddAsync(fact);
            }
            else
            {
               _applicationDbContext.Facts.Update(fact);
            }
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ShowFactAsync(Fact fact)
        {         
            return View(await _applicationDbContext.Facts.Where(x => x.Id == fact.Id).FirstOrDefaultAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

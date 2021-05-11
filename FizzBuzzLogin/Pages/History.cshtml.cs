using System.Collections.Generic;
using System.Linq;
using FizzBuzzLogin.Data;
using FizzBuzzLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FizzBuzzLogin.Pages
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly FizzBuzzContext _context;
        private readonly ILogger<HistoryModel> _logger;
        public HistoryModel(ILogger<HistoryModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<FizzBuzz> Fizzbuzz { get; set; }

        public void OnGet()
        {
            Fizzbuzz = _context.FizzBuzz.FromSqlRaw("select top 20 * from FizzBuzz order by Date desc").ToList();
        }
    }
}

using FizzBuzzLogin.Data;
using FizzBuzzLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FizzBuzzLogin.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
            FizzBuzz.Date = DateTime.Now;
            FizzBuzz.Result = "";
            if (FizzBuzz.Number % 3 == 0)
                FizzBuzz.Result += "Fizz";
            if (FizzBuzz.Number % 5 == 0)
                FizzBuzz.Result += "buzz";
            if (FizzBuzz.Result == "")
                FizzBuzz.Result = "Brak";
                _context.FizzBuzz.Add(FizzBuzz);
                await _context.SaveChangesAsync();
            }
            return Page();
        }
    }
}

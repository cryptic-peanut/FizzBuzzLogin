using System.Threading.Tasks;
using FizzBuzzLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzLogin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Data.FizzBuzzContext _context;
        public DeleteModel(Data.FizzBuzzContext context)
        {
            _context = context;
        }
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);
            if (FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FizzBuzz = await _context.FizzBuzz.FindAsync(id);
            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./History");
        }
    }
}

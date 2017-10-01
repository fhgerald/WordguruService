using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary.Statistics;

namespace WordGuru.Models.Groups
{
    public class CreateModel : PageModel
    {
        private readonly IStatisticsContext _statisticsContext;

        public CreateModel(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        [BindProperty]
        public Group Group { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _statisticsContext.AddGroup(Group);
            return RedirectToPage("./Index");
        }
    }
}

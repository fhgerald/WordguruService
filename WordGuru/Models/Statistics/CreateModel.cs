using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary.Statistics;

namespace WordGuru.Models.Statistics
{
    public class CreateModel : PageModel
    {
        private readonly IStatisticsContext _statisticsContext;

        public CreateModel(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        [BindProperty]
        public StatisticItem StatisticItem { get; set; }

        public Group Group { get; private set; }

        public async Task OnGetAsync(int id)
        {
            Group = _statisticsContext.GetGroup(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StatisticItem.Group = _statisticsContext.GetGroup(id);

            _statisticsContext.AddStatistics(StatisticItem);
            return RedirectToPage("./Index", new { groupId = id});
        }
    }
}

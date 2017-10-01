using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary.Statistics;

namespace WordGuru.Models.Groups
{
    public class IndexModel : PageModel
    {
        private readonly IStatisticsContext _statisticsContext;

        public IndexModel(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        public IEnumerable<Group> Groups { get; private set; }

        public async Task OnGetAsync()
        {
            Groups = _statisticsContext.GetGroups();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            _statisticsContext.DeleteGroup(id);

            return RedirectToPage();
        }
    }
}

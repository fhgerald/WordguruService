using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary.Statistics;

namespace WordGuru.Models.Statistics
{
    public class IndexModel : PageModel
    {
        private readonly IStatisticsContext _statisticsContext;

        public IndexModel(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        public IEnumerable<StatisticItem> StatisticItems { get; private set; }

        public Group Group { get; private set; }

        public async Task OnGetAsync(int groupId)
        {
            Group = _statisticsContext.GetGroup(groupId);
            if (Group != null)
            {
                StatisticItems = _statisticsContext.GetStatisticItems(groupId);
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int groupId, long id)
        {
            _statisticsContext.DeleteStatisticItem(id);

            return RedirectToPage(new {groupId = groupId});
        }
    }
}

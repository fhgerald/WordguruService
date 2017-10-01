using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary.Statistics;

namespace WordGuru.Models.Groups
{
    public class EditModel : PageModel
    {
        private readonly IStatisticsContext _statisticsContext;

        public EditModel(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        [BindProperty]
        public Group Group { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Group = _statisticsContext.GetGroup(id);

            if (Group == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _statisticsContext.UpdateGroup(Group.Id, Group.Name);

            return RedirectToPage("./Index");
        }
    }
}

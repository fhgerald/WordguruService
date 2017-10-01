using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WordGuru.Models.Api
{
    public class IndexModel : PageModel
    {
        public string BaseUri { get; private set; }

        public async Task OnGetAsync()
        {
            BaseUri = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}".ToLower();
        }

    }
}

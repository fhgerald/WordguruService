using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary;
using WordGuruLibrary.WordGenerator;

namespace WordGuru.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [DisplayName("Enter letters for words:")]
        public string Letter { get; set; }

        [BindProperty]
        [DisplayName("...or enter letter count for words:")]
        public int LetterCount { get; set; }

        [BindProperty]
        public string[] WordList { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var wordContext = new WordContext();

                if (!string.IsNullOrWhiteSpace(Letter))
                {
                    WordList = wordContext.GetWordWithLetters(Letter.ToCharArray()).ToArray();
                }
                else if (LetterCount > 0)
                {
                    WordList = wordContext.GetRandom(LetterCount).ToArray();
                }

                return Page();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

    }
}

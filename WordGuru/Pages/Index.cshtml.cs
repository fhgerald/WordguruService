using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WordGuruLibrary;

namespace WordGuru.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    public string Letter { get; set;  }

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
        wordContext.Read();

        WordList = wordContext.GetWordWithLetters(Letter.ToCharArray()).ToArray();
        return Page();
      }
      catch (Exception)
      {
        return new BadRequestResult();
      }
    }

  }
}

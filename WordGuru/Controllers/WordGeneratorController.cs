using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordGuruLibrary;

namespace WordGuru.Controllers
{
  [Route("api/[controller]")]
  public class WordGeneratorController : Controller
  {

    // GET api/wordgenerator/IUZ
    [HttpGet("{letter}")]
    public IActionResult Get(string letter)
    {
      try
      {
        var wordContext = new WordContext();
        wordContext.Read();

        var result = wordContext.GetWordWithLetters(letter.ToCharArray());
        return new ObjectResult(result);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }
  }
}

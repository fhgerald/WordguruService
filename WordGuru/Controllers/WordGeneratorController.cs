using System;
using Microsoft.AspNetCore.Mvc;
using WordGuruLibrary.WordGenerator;

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

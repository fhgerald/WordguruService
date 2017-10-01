using System;
using Microsoft.AspNetCore.Mvc;
using WordGuruLibrary.WordGenerator;

namespace WordGuru.Controllers
{
    [Route("api/[controller]")]
    public class RandomWordGeneratorController : Controller
    {

        // GET api/RandomWordGenerator/5
        [HttpGet("{letterCount}")]
        public IActionResult Get(int letterCount)
        {
            try
            {
                var wordContext = new WordContext();

                var result = wordContext.GetRandom(letterCount);
                return new ObjectResult(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

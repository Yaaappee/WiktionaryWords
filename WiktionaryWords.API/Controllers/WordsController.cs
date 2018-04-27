using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WiktionaryWords.API.Controllers
{
    [Route("api/[controller]")]
    public class WordsController : Controller
    {
        // GET api/words
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/words/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return id;
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WordGuruLibrary.Statistics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordGuru.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
        private readonly IStatisticsContext _statisticsContext;

        public GroupsController(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        // GET: api/groups
        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _statisticsContext.GetGroups();
        }

        // GET api/groups/5
        [HttpGet("{id}")]
        public Group Get(int id)
        {
            return _statisticsContext.GetGroup(id);
        }

        // POST api/groups
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _statisticsContext.AddGroup(value);
        }

        // PUT api/groups/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

            _statisticsContext.UpdateGroup(id, value);
        }

        // DELETE api/groups/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _statisticsContext.DeleteGroup(id);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WordGuruLibrary.Statistics;

namespace WordGuru.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsContext _statisticsContext;

        public StatisticsController(IStatisticsContext statisticsContext)
        {
            _statisticsContext = statisticsContext;
        }

        // GET: api/statistics/5
        [HttpGet("{groupId}")]
        public IEnumerable<ApiStatisticItem> Get(int groupId)
        {
            return _statisticsContext.GetStatisticItems(groupId).Select(x => new ApiStatisticItem(x))
                .OrderByDescending(x => x.Points).Take(20);
        }

        // POST api/statistics
        [HttpPost]
        public void Post([FromBody]ApiStatisticItem apiStatisticItem)
        {
            var statisticItem = CreateStatisticItem(apiStatisticItem);
            _statisticsContext.AddStatistics(statisticItem);
        }

        // PUT api/statistics
        [HttpPut]
        public void Put([FromBody]ApiStatisticItem apiStatisticItem)
        {
            var statisticItem = CreateStatisticItem(apiStatisticItem);

            _statisticsContext.UpdateStatistics(statisticItem);
        }


        // DELETE api/statistics/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _statisticsContext.DeleteStatisticItem(id);
        }

        private StatisticItem CreateStatisticItem(ApiStatisticItem apiStatisticItem)
        {
            var statisticItem = new StatisticItem()
            {
                DateTime = apiStatisticItem.DateTime,
                Name = apiStatisticItem.Name,
                Id = apiStatisticItem.Id,
                Group = _statisticsContext.GetGroup(apiStatisticItem.GroupId),
                Points = apiStatisticItem.Points
            };
            return statisticItem;
        }

    }
}

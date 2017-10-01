using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordGuruLibrary.Statistics;

namespace WordGuru.Controllers
{
    public class ApiStatisticItem
    {
        public ApiStatisticItem()
        {
            
        }

        public ApiStatisticItem(StatisticItem statisticItem)
        {
            Id = statisticItem.Id;
            GroupId = statisticItem.Group.Id;
            DateTime = statisticItem.DateTime;
            Name = statisticItem.Name;
            Points = statisticItem.Points;
        }

        public long Id { get; set; }
        public int GroupId { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public long Points { get; set; }
    }
}

using System.Collections.Generic;

namespace WordGuruLibrary.Statistics
{
    public interface IStatisticsContext
    {
        void AddGroup(string name);
        void AddGroup(Group group);
        void DeleteGroup(int id);
        Group GetGroup(int id);
        IEnumerable<Group> GetGroups();
        void UpdateGroup(int id, string name);

        void AddStatistics(StatisticItem statisticItem);
        void UpdateStatistics(StatisticItem statisticItem);
        IEnumerable<StatisticItem> GetStatisticItems(int groupId);
        void DeleteStatisticItem(long id);
    }
}
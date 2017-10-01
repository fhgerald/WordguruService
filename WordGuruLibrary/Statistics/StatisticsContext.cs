using System;
using System.Collections.Generic;
using LiteDB;

namespace WordGuruLibrary.Statistics
{
    public class StatisticsContext : IStatisticsContext
    {
        private const string StatisticsData = "Statistics.db";
        private const string GroupsCollection = "groups";
        private const string StatisticsCollection = "statistics";

        private readonly LiteDatabase _liteDatabase;

        public StatisticsContext()
        {
            _liteDatabase = new LiteDatabase(StatisticsData);
        }

        public IEnumerable<Group> GetGroups()
        {
            var groupCollection = _liteDatabase.GetCollection<Group>(GroupsCollection);
            return groupCollection.FindAll();
        }

        public Group GetGroup(int id)
        {
            var groupCollection = _liteDatabase.GetCollection<Group>(GroupsCollection);
            return groupCollection.FindById(id);
        }

        public void AddGroup(string name)
        {
            var group = new Group
            {
                Name = name
            };
            AddGroup(group);
        }

        public void AddGroup(Group group)
        {
            var groupCollection = _liteDatabase.GetCollection<Group>(GroupsCollection);

            groupCollection.Insert(group);
        }

        public void UpdateGroup(int id, string name)
        {
            var groupCollection = _liteDatabase.GetCollection<Group>(GroupsCollection);
            var group = groupCollection.FindById(id);
            if (group == null)
            {
                throw new InvalidOperationException("Group does not exist");
            }

            group.Name = name;

            groupCollection.Update(group);
        }

        public void DeleteGroup(int id)
        {
            var groupCollection = _liteDatabase.GetCollection<Group>(GroupsCollection);
            groupCollection.Delete(id);
        }

        public void AddStatistics(StatisticItem statisticItem)
        {
            var collection = _liteDatabase.GetCollection<StatisticItem>(StatisticsCollection);

            collection.Insert(statisticItem);
        }

        public void UpdateStatistics(StatisticItem statisticItem)
        {
            var collection = _liteDatabase.GetCollection<StatisticItem>(StatisticsCollection);

            collection.Update(statisticItem);
        }

        public IEnumerable<StatisticItem> GetStatisticItems(int groupId)
        {
            var collection = _liteDatabase.GetCollection<StatisticItem>(StatisticsCollection);

            return collection.Include(x => x.Group).Find(x => x.Group.Id == groupId);
        }

        public void DeleteStatisticItem(long id)
        {
            var collection = _liteDatabase.GetCollection<StatisticItem>(StatisticsCollection);
            collection.Delete(id);
        }
    }
}

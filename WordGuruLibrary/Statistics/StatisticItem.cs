using System;
using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace WordGuruLibrary.Statistics
{
    public class StatisticItem
    {
        public long Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public long Points { get; set; }

        [BsonRef("groups")]
        public Group Group { get; set; }

    }
}

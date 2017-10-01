using LiteDB;
using System.ComponentModel.DataAnnotations;

namespace WordGuruLibrary.Statistics
{
    public class Group
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}

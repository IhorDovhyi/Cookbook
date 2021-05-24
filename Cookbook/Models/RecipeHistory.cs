using System;

namespace Cookbook.Models
{
    public class RecipeHistory
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int child { get; set; } 

        public RecipeHistory()
        {
            date = DateTime.Now;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Recipe
    {
        //ID, Name, Time, Difficulty, Number of likes, Ingredients, Process, Tips and Tricks

        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Difficulty { get; set; }
        public int NumberOfLike { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }
        public string Tip { get; set; }
        public string Tricks { get; set; }
    }
}

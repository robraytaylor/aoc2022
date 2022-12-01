// See https://aka.ms/new-console-template for more information
using System.IO;

var inputLines = File.ReadAllLines("puzzle_input.txt");

var elfCalories = new List<int>();
var calorieCounter = 0;

foreach (var line in inputLines)
{
    if(string.IsNullOrWhiteSpace(line))
    {
        elfCalories.Add(calorieCounter);
        calorieCounter = 0;
    }
    else
    {
        calorieCounter += int.Parse(line);
    }
}

Console.WriteLine($"Highest Elf Calories = {elfCalories.Max()}");

Console.WriteLine($"Top 3 Elf Total Calories = {elfCalories.OrderByDescending(x => x).Take(3).Sum()}");
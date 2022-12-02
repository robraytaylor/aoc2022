

var resultPoints = new Dictionary<(string Opp, string Me), int> {
    { ("A", "X"), 3 + 1},
    { ("A", "Y"), 6 + 2},
    { ("A", "Z"), 0 + 3},
    { ("B", "X"), 0 + 1},
    { ("B", "Y"), 3 + 2},
    { ("B", "Z"), 6 + 3},
    { ("C", "X"), 6 + 1},
    { ("C", "Y"), 0 + 2},
    { ("C", "Z"), 3 + 3},
};

var resultPointsPart2 = new Dictionary<(string Opp, string Me), int> {
    { ("A", "X"), 0 + 3}, //Lose - 
    { ("A", "Y"), 3 + 1}, //Draw
    { ("A", "Z"), 6 + 2}, //Win
    { ("B", "X"), 0 + 1},
    { ("B", "Y"), 3 + 2},
    { ("B", "Z"), 6 + 3},
    { ("C", "X"), 0 + 2},
    { ("C", "Y"), 3 + 3},
    { ("C", "Z"), 6 + 1},
};

var data = File.ReadAllLines("puzzle_input.txt")
    .Select(x => x.Split(' '))
    .Select(x => new {Opp = x[0], Me = x[1]});

var totalScore = data.Sum(x => resultPoints[(x.Opp, x.Me)]);

Console.WriteLine($"Total Score Part 1 = {totalScore}");

var totalScorePart2 = data.Sum(x => resultPointsPart2[(x.Opp, x.Me)]);

Console.WriteLine($"Total Score Part 2 = {totalScorePart2}");
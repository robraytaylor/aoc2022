var lines = File.ReadAllLines("puzzle_input.txt");

(int Start, int End) GetRange(string range)
{
    var split = range.Split("-");
    return new (int.Parse(split[0]),int.Parse(split[1]));
}


var parsedData = lines
    .Select(x => x.Split(","))
    .Select(x => new {One = GetRange(x[0]), Two = GetRange(x[1])});

var completeOverlap = parsedData
    .Where(x => (x.One.Start <= x.Two.Start && x.One.End >= x.Two.End)
    || (x.Two.Start <= x.One.Start && x.Two.End >= x.One.End) );

var partialOverlap = parsedData
    .Where(x => (x.One.Start <= x.Two.Start && x.One.End >= x.Two.Start)
    || (x.One.Start >= x.Two.Start && x.One.End <= x.Two.Start)
    || (x.Two.Start <= x.One.Start && x.Two.End >= x.One.Start)
    || (x.Two.Start >= x.One.Start && x.Two.End <= x.One.Start));

Console.WriteLine($"Part 1 Result = {completeOverlap.Count()}");
Console.WriteLine($"Part 2 Result = {partialOverlap.Count()}");
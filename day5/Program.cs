using System.Text.RegularExpressions;

var lines = File.ReadAllLines("puzzle.txt");

var stackEnd = lines.ToList().IndexOf("");
var numberOfStacks = (lines[stackEnd-1].Length / 4) +1;
//Parse Stacks
Dictionary<int, Stack<char>> stacks = new();
Enumerable.Range(1, numberOfStacks).ToList().ForEach(x=> stacks[x] = new Stack<char>());

foreach(var line in lines.Take(stackEnd -1).Reverse())
{
    for(int i = 0; i<numberOfStacks; i++)
    {
        char item = line[1 + (i*4)];
        if(!string.IsNullOrWhiteSpace(item.ToString()))
            stacks[i+1].Push(item);
    }
}

//Parse Instructions
List<(int Count, int From, int To)> instructions = new();

foreach(var line in lines.Skip(stackEnd+1))
{
    Regex pattern = new Regex(@"move (?<count>\d+) from (?<from>\d+) to (?<to>\d+)");
    Match match = pattern.Match(line);
    int count = int.Parse(match.Groups["count"].Value);
    int from = int.Parse(match.Groups["from"].Value);
    int to = int.Parse(match.Groups["to"].Value);
    instructions.Add((count, from, to));
}

//Execute Instructions
foreach(var instruction in instructions)
{
    var items = new List<char>();
    for(int i = 0; i < instruction.Count; i++)
    {
        var item = stacks[instruction.From].Pop();
        items.Add(item);
    }
    items.Reverse();
    foreach(char item in items)
    {
        stacks[instruction.To].Push(item);
    }
}
string result = "";
foreach(var stack in stacks) {
    result += stack.Value.Pop();
}

Console.WriteLine(result);
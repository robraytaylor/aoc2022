// See https://aka.ms/new-console-template for more information

char GetMatchedItem(string rucksack)
{
    var middle = rucksack.Length /2;
    var one = rucksack.Substring(0,middle);
    var two = rucksack.Substring(middle, middle);

    char matched = '1';
    foreach (var c in one)
    {
        foreach (var c2 in two)
        {
            if(c == c2)
            {
                matched = c;
                break;
            }
        }
        if(matched != '1')
            break;
    }
    return matched;
}

int GetPriority(char c)
{
    // ascii a = 97, ascii A = 65
    if((int)c > 96)
        return (int)c - 96;
    else
        return (int)c - 64 + 26;
}

var input = File.ReadAllLines("puzzle_input.txt");

Console.WriteLine($"Priority Sum = {input.Sum(x => GetPriority(GetMatchedItem(x)))}");

var total = 0;

while(input.Any())
{
    var group = input.Take(3);
    input = input.Skip(3).ToArray();

    var distinctConcat = string.Join(string.Empty, group.Select(x => new string(x.Distinct().ToArray())));
    var badge = distinctConcat.GroupBy(x => x).Where(x => x.Count() == 3).First().Key;
    total += GetPriority(badge);
}

Console.WriteLine($"Badge Priority Sum = {total}");
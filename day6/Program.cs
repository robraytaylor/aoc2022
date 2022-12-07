var input = File.ReadAllText("puzzle_input.txt");

int i = 0;

while(input.Skip(i).Take(4).Distinct().Count() <4)
    i++;

Console.WriteLine($"4 Char marker appears after {i+4} characters");

int j = 0;

while(input.Skip(j).Take(14).Distinct().Count() < 14)
    j++;

Console.WriteLine($"14 Char marker appears after {j+14} characters");
using System.Numerics;

var monkeys = Monkey.TestMonkeys;
int iterations = 1_000;

for(int i=0; i< iterations; i++)
{
    Console.WriteLine(i);
    foreach(var monkey in monkeys)
    {
        while(monkey.Value.Items.TryDequeue(out BigInteger item))
        {
            item = monkey.Value.Operation(item);
            var target = monkey.Value.GetTarget(item);
            monkeys[target].Items.Enqueue(item);
            monkey.Value.Inspections++;
        }
    }
}

foreach(var monkey in monkeys)
{
    Console.WriteLine($"Monkey {monkey.Key} did {monkey.Value.Inspections} inspections");
}

var topMonkeys = monkeys
    .Select(x => x.Value)
    .OrderByDescending(x => x.Inspections)
    .Take(2).ToArray();

Console.WriteLine($"Monkey Business Level = {topMonkeys[0].Inspections*topMonkeys[1].Inspections}");
/*
Monkey 0 inspected items 101 times.
Monkey 1 inspected items 95 times.
Monkey 2 inspected items 7 times.
Monkey 3 inspected items 105 times.

Monkey 0 inspected items 52166 times.
Monkey 1 inspected items 47830 times.
Monkey 2 inspected items 1938 times.
Monkey 3 inspected items 52013 times.
*/
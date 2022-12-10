var lines = File.ReadAllLines("puzzle.txt");

var cycleNo = 0;
var x = 1;
var cycleValues = new Dictionary<int, int>();

var outputString = "";

string ProcessCycle(int x, int cycleNo)
{
    if(cycleNo % 40 >= x && cycleNo % 40 <= x+2)
        return "#";
    return ".";
}

foreach(var line in lines)
{
    if(line.StartsWith("addx"))
    {
        var instruction = int.Parse(line.Split(" ")[1]);
        cycleNo++;
        cycleValues.Add(cycleNo, x*cycleNo);
        outputString += ProcessCycle(x, cycleNo);

        cycleNo++;
        outputString += ProcessCycle(x, cycleNo);
        x = x + instruction;
        cycleValues.Add(cycleNo, x*cycleNo);

    }
    else
    {
        cycleNo++;
        cycleValues.Add(cycleNo, x*cycleNo);
        outputString += ProcessCycle(x, cycleNo);
    }
}
var signalStrength = cycleValues[20] + cycleValues[60] 
    + cycleValues[100] + cycleValues[140] 
    + cycleValues[180] + cycleValues[220]; 


Console.WriteLine($"Signal Strength = {signalStrength}");

Console.WriteLine();

for(int i = 0; i < outputString.Length; i=i+40)
{
    Console.WriteLine(outputString.Substring(i, 40));
}

/*
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
*/
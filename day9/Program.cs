var lines = File.ReadAllLines("puzzle.txt");

var instructions = lines.Select(x => x.Split(" "))
    .Select(x => (Direction : x[0], Steps : int.Parse(x[1])))
    .ToList();


var rope = Enumerable.Range(1, 10).Select(x => (x: 0, y: 0)).ToArray();
var positionLog = Enumerable.Range(0, 10).ToDictionary(x => x, _ => new List<(int x, int y)>() {(x: 0, y: 0)});


(int x, int y) GetNewTailPosition((int x, int y) head, (int x, int y) tail)
{
    var xDiff = head.x - tail.x;
    var yDiff = head.y - tail.y;
    var newTail = tail;
    if((Math.Abs(xDiff) > 1 || Math.Abs(yDiff) > 1))
    {
        newTail = (tail.x + Math.Sign(xDiff), tail.y + Math.Sign(yDiff));
    }
    return newTail;
}

foreach(var instruction in instructions)
{
    var moveVector = (x: 0, y: 0);
    if(instruction.Direction == "R")
        moveVector = (1,0);
    else if(instruction.Direction == "L")
        moveVector = (-1,0);
    else if(instruction.Direction == "U")
        moveVector = (0,1);
    else if(instruction.Direction == "D")
        moveVector = (0,-1);

    for(int i=0; i<instruction.Steps; i++)
    {
        rope[0] = (rope[0].x + moveVector.x, rope[0].y + moveVector.y);
        positionLog[0].Add(rope[0]);

        for(int j=1; j < rope.Length; j++)
        {
            rope[j] = GetNewTailPosition(rope[j-1], rope[j]);
            positionLog[j].Add(rope[j]);
        }
    }

}

Console.WriteLine($"2nd Node Positions = {positionLog[1].Distinct().Count()}");
Console.WriteLine($"Tail Node Positions = {positionLog[9].Distinct().Count()}");
var lines = File.ReadAllLines("puzzle.txt");

var trees = new Dictionary<(int x, int y), int>();

for(int i=0; i< lines.Length; i++)
    lines[i].Select((x, j) => (x, j)).ToList().ForEach(y => trees.Add((y.j, i), int.Parse(y.x.ToString())));

int width = trees.Select(t => t.Key.x).Max();
int height = trees.Select(t => t.Key.y).Max();
int visibleCount = 0;
foreach(var tree in trees)
{
    if(tree.Key.x == 0 || tree.Key.y == 0 || tree.Key.x == width || tree.Key.y == height)
    {
        visibleCount++;
        continue;
    }

    if(    trees.Where(t => t.Key.x == tree.Key.x && t.Key.y < tree.Key.y).All(t => t.Value < tree.Value)
        || trees.Where(t => t.Key.x == tree.Key.x && t.Key.y > tree.Key.y).All(t => t.Value < tree.Value)
        || trees.Where(t => t.Key.y == tree.Key.y && t.Key.x < tree.Key.x).All(t => t.Value < tree.Value)
        || trees.Where(t => t.Key.y == tree.Key.y && t.Key.x > tree.Key.x).All(t => t.Value < tree.Value)
    )
    {
        visibleCount++;
    }
}

Console.WriteLine($"Total Visible Trees = {visibleCount}");

var treeScores = new List<int>();

foreach(var tree in trees)
{
    int GetVisibleTrees(KeyValuePair<(int x, int y), int> tree, int xStep, int yStep)
    {
        int treeCount = 0;
        int nextX = tree.Key.x + xStep;
        int nextY = tree.Key.y + yStep;
        while(trees.ContainsKey((nextX, nextY)))
        {
            treeCount++;
            var currentHeight = trees[(nextX, nextY)];
            nextX = nextX + xStep;
            nextY = nextY + yStep;
            if(currentHeight >= tree.Value)
                return treeCount;
        }
        return treeCount;
    }
    
    treeScores.Add(GetVisibleTrees(tree, -1, 0)
        * GetVisibleTrees(tree, 1, 0) 
        * GetVisibleTrees(tree, 0, -1) 
        * GetVisibleTrees(tree, 0, 1));
}

Console.WriteLine($"Highest Visiblity Score = {treeScores.Max()}");
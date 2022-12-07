var lines = File.ReadAllLines("puzzle_input.txt");

var directorySizes = new Dictionary<string, double>();

var currentDirectories = new List<string>();
var currentDirectory = "";

foreach(var currentLine in lines)
{   
    if(currentLine == "$ cd ..")
    {
        currentDirectories.Remove(currentDirectory);
        currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("-"));
    }
    else if(currentLine.StartsWith("$ cd "))
    {
        currentDirectory = currentDirectory+=$"-{currentLine.Replace("$ cd ", "")}";
        currentDirectories.Add(currentDirectory);
    }

    if(int.TryParse(currentLine.Split(" ")[0], out int fileSize))
    {
        currentDirectories.ForEach(x=>{
            if(directorySizes.ContainsKey(x))
                directorySizes[x]+=fileSize;
            else
                directorySizes[x] = fileSize;

        });
    }
}

Console.WriteLine($"Sum of Directorys under 100,000 = {directorySizes.Values.Where(x => x<=100_000).Sum()}");

var totalData = directorySizes["-/"];
var spaceToClear = 30_000_000 - (70_000_000 - totalData);
var sizeOfDirectoryToDelete = directorySizes.Where(x => x.Value > spaceToClear).OrderBy(x => x.Value).First().Value;

Console.WriteLine($"The size of the directory to delete is {sizeOfDirectoryToDelete}");
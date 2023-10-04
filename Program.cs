using System.Text;
using DuplicateFileFinderCs;

string searchDir = ".";

if (args.Length > 0) {
    searchDir = args[0];
    if (!Directory.Exists(searchDir)) {
        Console.WriteLine($"{searchDir} is not a valid path");
        Environment.Exit(1);
    }
}

Mole mole = new();
var duplicates = mole.DigIn(searchDir);

if (duplicates.Count == 0) {
    Console.WriteLine($"The mole was not able to find any duplicate files in {searchDir}");
    return;
}

foreach (var dup in duplicates) {
    Console.WriteLine(dup.Key);
}


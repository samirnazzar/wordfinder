// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Welcome to WordFinder!");
Console.WriteLine("");

var matrixFilePath = Path.Combine(Environment.CurrentDirectory, "WordFinderMatrix.txt");
var wordStreamFilePath = Path.Combine(Environment.CurrentDirectory, "WordFinderWordStream.txt");

if (File.Exists(matrixFilePath))
{
    if (File.Exists(wordStreamFilePath))
    {
        List<string> matrix = new List<string>();
        List<string> wordStream = new List<string>();

        using (var sr = new StreamReader(matrixFilePath))
        {
            while (sr.Peek() >= 0)
                matrix.Add(sr.ReadLine());
        }

        using (var sr = new StreamReader(wordStreamFilePath))
        {
            while (sr.Peek() >= 0)
                wordStream.Add(sr.ReadLine());
        }

        var wordFinder = new WordFinder.Business.WordFinder(matrix);
        var result = wordFinder.Find(wordStream);

        foreach (var word in result)
            Console.WriteLine($"{word}");
    }
    else
    {
        Console.WriteLine($"File {wordStreamFilePath} was not found, please add a file and try again");
    }    
}
else
{
    Console.WriteLine($"File {matrixFilePath} was not found, please add a file and try again");
}

Console.ReadLine();

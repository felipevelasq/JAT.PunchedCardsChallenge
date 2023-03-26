// See https://aka.ms/new-console-template for more information
using JAT.PunchedCardsGenerator;

do
{
    Console.WriteLine();
    Console.Write("Number of rows: ");
    int nRows = Convert.ToInt32(Console.ReadLine() ?? "0");
    Console.Write("Number of columns: ");
    int nColumns = Convert.ToInt32(Console.ReadLine() ?? "0");
    using (StreamReader reader = new StreamReader(PunchedCardGenerator.Generate(nRows, nColumns)))
    {
        Console.Write(reader.ReadToEnd());
    }
} while (Console.ReadLine() != "e");
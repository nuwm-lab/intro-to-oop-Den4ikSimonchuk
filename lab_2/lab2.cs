using System;

public class ArithmeticProgression
{
    public int FirstTerm { get; set; }
    public int Difference { get; set; }
    public int NumberOfTerms { get; set; }

    public ArithmeticProgression(int firstTerm, int difference, int numberOfTerms)
    {
        FirstTerm = firstTerm;
        Difference = difference;
        NumberOfTerms = numberOfTerms;
    }

    public int CalculateSum()
    {
        int sum = 0;
        for (int i = 0; i < NumberOfTerms; i++)
        {
            sum += FirstTerm + i * Difference;
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        ArithmeticProgression progression = new ArithmeticProgression(1, 2, 5); // Приклад: 1, 3, 5, 7, 9
        int sum = progression.CalculateSum();
        Console.WriteLine($"Сума прогресії: {sum}");
    }
}

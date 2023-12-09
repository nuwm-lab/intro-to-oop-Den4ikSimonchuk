using System;

public class ArithmeticProgression
{
    public int FirstTerm { get; private set; }
    public int Difference { get; private set; }
    public int NumberOfTerms { get; private set; }
    private int progressionNumber;

    public ArithmeticProgression(int progressionNumber, int firstTerm, int difference, int numberOfTerms)
    {
        this.progressionNumber = progressionNumber;
        FirstTerm = firstTerm;
        Difference = difference;
        NumberOfTerms = numberOfTerms;
    }

    ~ArithmeticProgression()
    {
        Console.WriteLine($"Progression {progressionNumber} destroyed.");
    }

    public int CalculateSum()
    {
        return NumberOfTerms * (2 * FirstTerm + (NumberOfTerms - 1) * Difference) / 2;
    }

    public override string ToString()
    {
        return $"{progressionNumber}";
    }
}

class Program
{
    private static void Task()
    {
        Console.Write("Enter the number of arithmetic progressions: ");
        int count = int.Parse(Console.ReadLine());

        ArithmeticProgression[] progressions = new ArithmeticProgression[count];
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int firstTerm = random.Next(1, 10);
            int difference = random.Next(1, 10);
            int numberOfTerms = random.Next(1, 10);
            progressions[i] = new ArithmeticProgression(i + 1, firstTerm, difference, numberOfTerms);
        }

        int maxSum = 0, maxIndex = -1;
        for (int i = 0; i < count; i++)
        {
            int currentSum = progressions[i].CalculateSum();
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxIndex = i;
            }
        }

        Console.WriteLine($"Progression with the largest sum: {progressions[maxIndex]} (Sum: {maxSum})");
    }

    static void Main(string[] args)
    {
        double memory1 = GC.GetTotalMemory(true);
        Console.WriteLine($"{memory1} bytes");
        Task();
        double memory2 = GC.GetTotalMemory(true);
        Console.WriteLine($"{memory2} bytes");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        double memory3 = GC.GetTotalMemory(true);
        Console.WriteLine($"{memory3} bytes");
        Console.ReadLine();
    }
}


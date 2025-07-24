using System;

class CookingMasterclass
{
    static void Main()
    {
        // Входни данни
        double budget = double.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        double priceFlour = double.Parse(Console.ReadLine());
        double priceEgg = double.Parse(Console.ReadLine());
        double priceApron = double.Parse(Console.ReadLine());

       
        int apronsCount = (int)Math.Ceiling(students * 1.2);

       
        int freeFlour = students / 5;
        int flourCount = students - freeFlour;

       
        double totalCost = (priceApron * apronsCount) +
                           (priceEgg * 10 * students) +
                           (priceFlour * flourCount);

        if (totalCost <= budget)
        {
            Console.WriteLine($"Items purchased for {totalCost:F2}$.");
        }
        else
        {
            double needed = totalCost - budget;
            Console.WriteLine($"{needed:F2}$ more needed.");
        }
    }
}

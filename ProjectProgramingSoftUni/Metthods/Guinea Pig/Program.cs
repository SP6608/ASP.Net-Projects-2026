namespace Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quantityFood=double.Parse(Console.ReadLine())*1000;
            double quantitHey = double.Parse(Console.ReadLine()) * 1000;
            double quantityCver=double.Parse(Console.ReadLine()) *1000;
            double guineaWeight = double.Parse(Console.ReadLine()) * 1000;
            for (int i = 1; i <=30; i++)
            {
                quantityFood -= 300;
                if (i%2==0)
                {
                    quantitHey -= 0.05 * quantityFood;
                }
                if (i % 3 == 0)
                {
                    quantityCver -= guineaWeight / 3;
                }
                if (quantityFood<=0||quantitHey<=0||quantityCver<=0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(quantityFood/1000):f2}, Hay: {(quantitHey/1000):f2}, Cover: {(quantityCver/1000):f2}.");
        }
    }
}

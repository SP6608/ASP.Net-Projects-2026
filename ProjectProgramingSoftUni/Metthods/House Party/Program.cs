namespace House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number=int.Parse(Console.ReadLine());
            List<string> listOfOwners    = new List<string>();
            for (int i = 0; i < number; i++)
            {
              List<string> input=Console.ReadLine().Split().ToList();
                if (input.Count==3)
                {
                    if (listOfOwners.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else 
                    { 
                       listOfOwners.Add(input[0]);
                    }
                }
                else if (input.Count==4)
                {
                    if (listOfOwners.Contains(input[0]))
                    {
                        listOfOwners.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }
               
            }//end for
            foreach (string name in listOfOwners) 
            {
                Console.WriteLine(name);
            }
        }
    }
}

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> vagons = Console.ReadLine().Split().Select(int.Parse).ToList();
           int vagonCapacity=int.Parse(Console.ReadLine());
           var command=Console.ReadLine().Split(' ').ToList();
            while (command[0]!="end")
            {
                if (command[0]=="Add")
                {
                    int pasagers = int.Parse(command[1]);
                    vagons.Add(pasagers);
                }
                else
                {
                    int pasager = int.Parse(command[0]);
                    for (int i = 0; i < vagons.Count; i++)
                    {
                        if (vagons[i]+pasager<=vagonCapacity)
                        {
                            vagons[i] += pasager;
                            break;
                        }
                    }
                }
               command = Console.ReadLine().Split(' ').ToList();
            }
            Console.WriteLine(string.Join(' ',vagons));
        }
    }
}

namespace Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers =Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine().Split().ToList();
            int element,position;
            while (command[0]!="end")
            {
                switch (command[0])
                {
                    case "Delete":
                        element=int.Parse(command[1]);
                        numbers.RemoveAll(x => x == element);
                        break;
                    case "Insert":
                        element=int.Parse (command[1]);
                        position=int.Parse(command[2]);
                        numbers.Insert(position,element);
                        break;
                }
                command = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}

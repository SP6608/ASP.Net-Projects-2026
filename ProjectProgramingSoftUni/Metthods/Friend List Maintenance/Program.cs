using System;
using System.Collections.Generic;
using System.Linq;

namespace Friend_List_Maintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfFriends = Console.ReadLine().Split(", ").ToList();
            var command = Console.ReadLine().Split().ToList();

            while (command[0] != "Report")
            {
                switch (command[0])
                {
                    case "Blacklist":
                        string name = command[1];
                        if (!listOfFriends.Contains(name))
                        {
                            Console.WriteLine($"{name} was not found.");
                        }
                        else
                        {
                            int indexOfName = listOfFriends.IndexOf(name);
                            listOfFriends[indexOfName] = "Blacklisted";
                            Console.WriteLine($"{name} was blacklisted.");
                        }
                        break;

                    case "Error":
                        int index = int.Parse(command[1]);
                        if (index >= 0 && index < listOfFriends.Count &&
                            listOfFriends[index] != "Blacklisted" && listOfFriends[index] != "Lost")
                        {
                            string lostName = listOfFriends[index];
                            listOfFriends[index] = "Lost";
                            Console.WriteLine($"{lostName} was lost due to an error.");
                        }
                        break;

                    case "Change":
                        int indexTwo = int.Parse(command[1]);
                        string newName = command[2];
                        if (indexTwo >= 0 && indexTwo < listOfFriends.Count)
                        {
                            string currentName = listOfFriends[indexTwo];
                            listOfFriends[indexTwo] = newName;
                            Console.WriteLine($"{currentName} changed his username to {newName}.");
                        }
                        break;
                }

                command = Console.ReadLine().Split().ToList();
            }

            int countBlackNames = listOfFriends.Count(x => x == "Blacklisted");
            int countLostNames = listOfFriends.Count(x => x == "Lost");

            Console.WriteLine($"Blacklisted names: {countBlackNames}");
            Console.WriteLine($"Lost names: {countLostNames}");
            Console.WriteLine(string.Join(" ", listOfFriends));
        }
    }
}

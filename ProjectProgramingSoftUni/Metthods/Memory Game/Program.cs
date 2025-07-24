using System;
using System.Collections.Generic;
using System.Linq;

namespace Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();
            int moves = 0;

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                moves++;

                int firstIndex = int.Parse(command[0]);
                int secondIndex = int.Parse(command[1]);

                bool invalidInput = firstIndex == secondIndex ||
                                    firstIndex < 0 || secondIndex < 0 ||
                                    firstIndex >= elements.Count || secondIndex >= elements.Count;

                if (invalidInput)
                {
                    string element = $"-{moves}a";
                    int middleIndex = elements.Count / 2;
                    elements.InsertRange(middleIndex, new string[] { element, element });
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (elements[firstIndex] == elements[secondIndex])
                    {
                        string matchedElement = elements[firstIndex];
                        Console.WriteLine($"Congrats! You have found matching elements - {matchedElement}!");

                        // Винаги премахваме първо елемента с по-големия индекс
                        if (firstIndex > secondIndex)
                        {
                            elements.RemoveAt(firstIndex);
                            elements.RemoveAt(secondIndex);
                        }
                        else
                        {
                            elements.RemoveAt(secondIndex);
                            elements.RemoveAt(firstIndex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }

                // Проверка дали всички елементи са намерени
                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }

                command = Console.ReadLine().Split();
            }

            // Ако е въведено "end" и все още има елементи:
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

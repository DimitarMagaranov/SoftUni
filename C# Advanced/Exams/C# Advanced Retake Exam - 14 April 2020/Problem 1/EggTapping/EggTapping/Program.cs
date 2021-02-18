using System;
using System.Collections.Generic;
using System.Linq;

namespace EggTapping
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerEggsString = Console.ReadLine();

            char[] firstcharlist = firstPlayerEggsString.ToCharArray();

            Queue<char> firstPlayerEggs = new Queue<char>(firstcharlist.Where(x => x != ' ').ToArray());

            string secPlayerEggsString = Console.ReadLine();

            char[] secondcharlist = secPlayerEggsString.ToCharArray();

            Stack<char> secondPlayerEggs = new Stack<char>(secondcharlist.Where(x => x != ' ').ToArray());

            int totalScoreFirstPlayer = 0;
            int totalScoreSecondPlayer = 0;


            while (true)
            {
                char charFirstPlayer = firstPlayerEggs.Peek();
                char charSecondPlayer = secondPlayerEggs.Peek();

                int asciiValueFirstPlayer = (int)charFirstPlayer;
                int asciiValueSecondPlayer = (int)charSecondPlayer;

                if (asciiValueFirstPlayer > asciiValueSecondPlayer)
                {
                    int value = asciiValueSecondPlayer + 1;
                    char charToAdd = (char)value;

                    secondPlayerEggs.Pop();
                    totalScoreSecondPlayer += (int)firstPlayerEggs.Dequeue();
                    secondPlayerEggs.Push(charToAdd);
                }
                else if (asciiValueFirstPlayer < asciiValueSecondPlayer)
                {
                    int value = asciiValueFirstPlayer + 1;
                    char charToAdd = (char)value;

                    firstPlayerEggs.Dequeue();
                    totalScoreFirstPlayer += (int)secondPlayerEggs.Pop();
                    firstPlayerEggs.Enqueue(charToAdd);
                }
                else
                {
                    firstPlayerEggs.Dequeue();
                    secondPlayerEggs.Pop();
                }

                if (firstPlayerEggs.Any() == false || secondPlayerEggs.Any() == false)
                {
                    break;
                }
            }

            if (totalScoreFirstPlayer > totalScoreSecondPlayer)
            {
                Console.WriteLine($"The winner ends with {totalScoreFirstPlayer} points.");
                Console.WriteLine($"There are {string.Join(", ", firstPlayerEggs)} in his collection.");
            }
            else if(totalScoreFirstPlayer < totalScoreSecondPlayer)
            {
                Console.WriteLine($"The winner ends with {totalScoreSecondPlayer} points.");
                Console.WriteLine($"There are {string.Join(", ", secondPlayerEggs)} in his collection.");
            }
            else
            {
                Console.WriteLine("Draw! Nobody wins.");
            }
        }
    }
}

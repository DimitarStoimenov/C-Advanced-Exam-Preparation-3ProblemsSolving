using System;
using System.Linq;

namespace The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armory = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int armRow = 0;
            int armCol = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().ToCharArray();

                matrix[i] = input;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'A')
                    {
                        armRow = i;
                        armCol = j;
                        break;
                    }
                }
            }

            
            while (true)
            {
                string commandLine = Console.ReadLine();
                string command = commandLine.Split()[0];
                int orcRow = int.Parse(commandLine.Split()[1]);
                int orcCol = int.Parse(commandLine.Split()[2]);
                matrix[orcRow][orcCol] = 'O';
                armory--;
                matrix[armRow][armCol] = '-';
                if (command == "up" && armRow -1 >= 0)
                {
                    armRow--;
                }
                else if (command == "down" && armRow + 1 < n )
                {
                    armRow++;
                }
                else if (command == "left" && armCol -1 >= 0 )
                {
                    armCol--;
                }
                else if (command == "right" && armCol + 1 < matrix[armRow].Length)
                {
                    armCol++;
                }
                if (matrix[armRow][armCol] == 'O')
                {
                    matrix[armRow][armCol] = '-';
                    armory -= 2;
                }
                if (matrix[armRow][armCol] == 'M')
                {
                    matrix[armRow][armCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armory}");
                    break;
                }
                if (armory <= 0)
                {
                    matrix[armRow][armCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armRow};{armCol}.");
                    break;
                }

                matrix[armRow][armCol] = 'A';

            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(matrix[i]);
            }
        }
    }
}

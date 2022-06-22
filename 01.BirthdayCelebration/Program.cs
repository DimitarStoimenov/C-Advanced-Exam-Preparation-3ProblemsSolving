using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] eatingCapacityOfAPerson = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] plates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> capacityOfPerson = new Queue<int>(eatingCapacityOfAPerson);
            Stack<int> stackPlates = new Stack<int>(plates);
            int wastedFood = 0;
           

            while (capacityOfPerson.Count > 0 && stackPlates.Count > 0)
            {
                if (capacityOfPerson.Peek() <= stackPlates.Peek())
                {
                   
                    int currCapacityPerson =   stackPlates.Peek() - capacityOfPerson.Peek();
                   
                    capacityOfPerson.Dequeue();
                    stackPlates.Pop();
                    
                    wastedFood += currCapacityPerson;
                }
               else if (capacityOfPerson.Peek() > stackPlates.Peek())
                {
                   
                    int currPerson = capacityOfPerson.Peek();
                    

                    while (currPerson > 0)

                    {

                        if (currPerson < stackPlates.Peek())
                        {
                            wastedFood += stackPlates.Peek() - currPerson;
                            currPerson = 0;
                            capacityOfPerson.Dequeue();
                            stackPlates.Pop();
                            break;
                        }
                        int curr = currPerson - stackPlates.Pop();
                        if (curr <= 0)
                        {
                            
                            capacityOfPerson.Dequeue();
                            wastedFood += curr;
                        }

                        currPerson = curr;
                        
                      


                    }

                }

            }

            if (capacityOfPerson.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", stackPlates)}");
               
                Console.WriteLine($"Wasted grams of food: {Math.Abs(wastedFood)}");
            }

            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", capacityOfPerson)}");
               
                Console.WriteLine($"Wasted grams of food: {Math.Abs(wastedFood)}");
            }


        }
    }
}

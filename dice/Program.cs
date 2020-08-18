using System;
using System.ComponentModel.DataAnnotations;

namespace dice
{
    class Program
    {
        static void Main(string[] args)
        {
            // because of while statement Dice values keep resetting welp.
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = Menu();
            }

            Console.ReadLine();

        }

        static bool Menu()
        {
            Dice myDice = new Dice();
            Console.Clear();
            Console.WriteLine("let's Roll!");
            Console.WriteLine(string.Format("Currently Rolling: D{0}\nModifiers: {1}", myDice.sides, myDice.modifier));
            Console.WriteLine("1) Roll the dice");
            Console.WriteLine("2) Change settings");
            Console.WriteLine("3) Exit");
            string navigate = Console.ReadLine();
            if (navigate == "1")
            {
                Console.Clear();

                bool Roll = true;
                do
                {
                    int newRoll = myDice.RollDie(myDice.sides, myDice.modifier);
                    Console.WriteLine(string.Format("you rolled a {0}", newRoll));
                    Console.WriteLine("roll again? Y/N");
                    string response = Console.ReadLine();
                    if (response == "N")
                    {
                        Roll = false;
                    }
                    else if (response != "Y")
                    {
                        Console.WriteLine("if you'd like to leave, please type N.");

                        break;
                    }
                } while (Roll);
                return true;

            }
            else if (navigate == "2")
            {
                Console.Clear();
                Console.Write(string.Format("Dice curently has {0}, changing it to: ", myDice.sides));
                int number;
                bool canParse = Int32.TryParse(Console.ReadLine(), out number);
                if (canParse)
                {
                    myDice.sides = number;
                    Console.WriteLine(string.Format("number of sides has been changed to: {0}", myDice.sides));
                }
                else
                {
                    Console.WriteLine("failed, not a number");
                }
                
                Console.Write(string.Format("Modifier is set to {0}, changing it to: ", myDice.modifier));
                canParse = Int32.TryParse(Console.ReadLine(), out number);
                if (canParse)
                {
                    myDice.modifier = number;
                    if ((myDice.modifier + myDice.sides) < 1)
                    {
                        Console.WriteLine("not a legitimate die, increase either your modifier or the amount of sides");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("number of sides has been changed to: {0}", myDice.modifier));
                    }
                    
                }
                else
                {
                    Console.WriteLine("failed, not a number");
                }



                Console.ReadLine();
                return true;


            }
            else if (navigate == "3")
            {
                Console.Clear();
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("not a valid option, press enter and choose again.");
                Console.ReadLine();
                return true;
            }

        }
    }

     public class Dice
    {
        public int sides = 6;
        public int modifier = 0;
        private static readonly Random rnd = new Random();
        public int RollDie(int sides, int modifier)
        {
            
            int max = sides + modifier + 1;
            int num = rnd.Next(1,max);
            return num;
        }
    }
}

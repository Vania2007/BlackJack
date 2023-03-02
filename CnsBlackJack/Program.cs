using CardLib;
using System;

namespace CnsBlackJack
{
    class Program
    {
        static BlackJackGame game = new BlackJackGame();
        public static void Process()
        {
            
            game.Start();
            Console.WriteLine("Will you take one more card?\nWrite 'Yes' or 'No'");
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {
                game.Hit();
            }
            game.Pass();
            game.DealerAction();
            game.Pass();
        }
        static void Main(string[] args)
        {
            Process();
        }
        
    }
}

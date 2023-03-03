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
            Console.WriteLine($"{game.Player.Hand[0]}, {game.Player.Hand[1]}"); //показати карти, щщо в руці гравця до моменту, брати ще чи ні
            Console.WriteLine("Will you take one more card?\nWrite 'Yes' or 'No'"); 
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {
                game.Hit();
            }
            game.Pass();
            game.DealerAction();
            game.Pass();
            Console.WriteLine($"{game.GetWinner()}, {game.Winner}: {game.Points(game.Winner)}");
        }
        static void Main(string[] args)
        {
            Process();
        }
        
    }
}

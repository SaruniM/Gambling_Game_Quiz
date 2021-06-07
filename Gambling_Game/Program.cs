using System;

namespace GuessGame
{
    public class GuessGame
    {
     
        public class Game
        {
            public int attempt { set; get; } = 0;
            public override string ToString()
            {
                return $"The player's attempt <{attempt}>";
            }
        }
        public static void Test()
        {
            Console.WriteLine("Lets play the Game");
            var game = new Game();
            PlayGame(game);
        }
        public static void PlayGame(Game game)
        {
            Console.WriteLine(game);
            var comNum = GenerateComNum();
            Console.WriteLine($"This is for test: ComNum is {comNum}");
            do
            {
                var userNum = GenerateUserNum();
                CompareNum(userNum, comNum, game);
                Console.WriteLine(game);

            } while (game.attempt > 0);
        }

        static void CompareNum(int userNum, int comNum, Game game)
        {

            if (userNum % comNum == 0)
            {
                Console.WriteLine("WIN! 100 Point!\n");
                game.attempt--;
                if (comNum % userNum == 0)
                {
                    Console.WriteLine("WIN! 100 Point!\n");
                    game.attempt--;
                }
            }
            else if (userNum % 2 == 1)
            {
                Console.WriteLine("LOSE! 0 Points");
                Console.WriteLine();
                PlayGame(game);
            }
            else if (userNum % 2 == 0 && userNum % comNum == 0)
            {
                Console.WriteLine("{userNum} Try Again!");
                Console.WriteLine();
                PlayGame(game);
            }
            else if (userNum % 2 == 0 && comNum % userNum == 0)
            {
                Console.WriteLine("{userNum} Try Again!");
                Console.WriteLine();
                PlayGame(game);
            }
        }
        static int GenerateUserNum()
        {
            int userNum;
            Console.Write("Please enter the num btw 1-100\t\t");
            while (!Int32.TryParse(Console.ReadLine(), out userNum))
            {
                Console.WriteLine("Invalid num please input whole num");
            }
            return userNum;
        }
        static int GenerateComNum()
        {
            Random rnd = new Random();
            var comNum = rnd.Next(1, 101);
            return comNum;
        }
    }
}

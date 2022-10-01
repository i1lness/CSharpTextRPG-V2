using System;

namespace CSharpTextRPG_V2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while(true)
            {
                if (game.GetGameMode() == GameMode.None)
                {
                    Console.WriteLine("게임을 종료합니다");
                    break;
                }
                else { game.Process(); }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {

        

        static void Main(string[] args)
        {

            // Console.WriteLine("██");
            // Console.WriteLine("░░");
            // Console.WriteLine("▒▒");
            // Console.WriteLine("▓▓");



            PlayGround FirstPLayGround = new PlayGround();
            FirstPLayGround.CreatePlayGround();

            Snake FirstSnake = new Snake();

            FirstPLayGround.DrawPlayGround(Game.newPlayGround);

            while (true)
            {
                if (Game.ready)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    FirstSnake.Move(key);
                }


            }

           
         


            Console.ReadLine();

        }
    }
}

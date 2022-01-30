using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake
{
    internal class Program
    {
        public static Snake FirstSnake = new Snake();
        public static bool GameStarted = false;
        public static ConsoleKeyInfo KeyPressed;

        static void Main(string[] args)
        {
        
            Thread thread = new Thread(new ThreadStart(SnakeMoving));   // Отдельный поток для отрисовки новой картинки раз в 0.5 секунд
            thread.Start();

            PlayGround.CreatePlayGround();                              // Создаем игровое поле
 
            PlayGround.DrawPlayGround();                                // Рисуем игровое поле

    

            while (true)                                                // Отлавливаем нажатие клавиши 
            {

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (GameStarted == false && Game.IsKeyWASD(key))
                {
                    GameStarted = true;
                }

                if (GameStarted == true && Game.IsKeyWASD(key))
                {
                    KeyPressed = key;                                   // Двигаться в змейке мы не можем - мы можем только менять направление движения,
                                                                        // поэтому просто передаем значение нажатой клавиши в SnakeMoving ()
                }

            }


        }
     

        static void SnakeMoving ()
        {

            while (true)
            {

                if (GameStarted && Game.IsKeyWASD(KeyPressed) && Game.IsRightDirect(KeyPressed, FirstSnake.SnakeDirection))             // Было ли передано нажатие клавиши, началась ли игра
                                                                                                                                        // Была ли нажата одна из подходящих клавиш
                                                                                                                                        // И не захотел ли игрок начать движение в противоположную сторону
                {
                    FirstSnake.Move(KeyPressed);                                                                                        // Двигаем змейку
                    KeyPressed = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);                                     // Обнуляем значение нажатой клавиши (заменяем на " ")
                }
                else                                                                                                                    // Если нажатия не было - продолжаем движение в том же векторе
                {
                    if (string.Equals(FirstSnake.SnakeDirection, "W"))
                    {
                        FirstSnake.Move(new ConsoleKeyInfo('W', ConsoleKey.W, false, false, false));
                    }
                    if (string.Equals(FirstSnake.SnakeDirection, "D"))
                    {
                        FirstSnake.Move(new ConsoleKeyInfo('D', ConsoleKey.D, false, false, false));
                    }
                    if (string.Equals(FirstSnake.SnakeDirection, "A"))
                    {
                        FirstSnake.Move(new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false));
                    }
                    if (string.Equals(FirstSnake.SnakeDirection, "S"))
                    {
                        FirstSnake.Move(new ConsoleKeyInfo('S', ConsoleKey.S, false, false, false));
                    }
                }

                                         
     
                Thread.Sleep(500);          

                

            }
            

        }





    }



}

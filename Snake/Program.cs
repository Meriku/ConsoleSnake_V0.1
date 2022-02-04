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
        static object locker = new object();

        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 45);
            Console.SetBufferSize(110, 45);
            Console.CursorVisible = false;
            Game.ToDraw(10,2, "To start press 'W'");                    
            
            Thread SnakeMove = new Thread(new ThreadStart(SnakeMoving));    // Отдельный поток для постоянного движения змеи      
            PlayGround.CreatePlayGround();                                  // Создаем игровое поле
     
            while (true)                                                    // Отлавливаем нажатие клавиши 
            {
                ConsoleKeyInfo PressedKey = Console.ReadKey(true);          // Записываем значение кнопки
                if (!Game.IsStarted && Game.IsKeyWASD(PressedKey))          // Если была нажата кнопка WASD - начинаем игру 
                {
                    Game.IsStarted = true;
                    Game.GenerateFood();
                    SnakeMove.Start();
                }
              
                if (Game.IsStarted && Game.IsKeyWASD(PressedKey) && Game.IsKeyRightDirect(PressedKey, Game.OldPressedKey))
                {                                                           // Если игра начата, передаем нажатие кнопки для дальнейшей обработки
                    lock (locker)
                    {
                        Snake.MoveAndDraw(PressedKey);                      // Передаем нажатую кнопку для движение в заданную сторону

                    }
                }
            }
        }
     

        static void SnakeMoving ()                                      // Отдельный поток для движения змеи без участия игрока 
        {           
            while (true)
            {
                lock (locker)
                {
                    Snake.MoveAndDraw(Game.OldPressedKey);              // Движемся в ту сторону в которую двигались до этого 
                    Thread.Sleep(150);

                }
            }           
        }
    }



}

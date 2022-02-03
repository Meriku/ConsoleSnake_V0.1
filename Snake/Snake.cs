using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    public class Snake : Game
    {
              
        public static void MoveAndDraw(ConsoleKeyInfo pressedkey)
        {
            var CenterOfCalcPlayGroundX = CalculatingPlayGround.GetLength(0) / 2;
            var CenterOfCalcPlayGroundY = CalculatingPlayGround.GetLength(1) / 2;

            ToDrawScore();

            if (SnakeCordinates.Count < 4) { SnakeAddFourElements(); }      // Создание змейки первый раз в игре


            for (int n = SnakeCordinates.Count - 1; n >= 1; n--)    // Сохраняем в n максимальный индекс списка и идем от большего к меньшему
            {
                SnakeCordinates[n][0] = SnakeCordinates[n - 1][0];  // X 
                SnakeCordinates[n][1] = SnakeCordinates[n - 1][1];  // Y

            }


            int[] direction = GetDirection(pressedkey);             // Получаем направление движения по переданному значению нажатой кнопки

            SnakeCordinates[0][0] += direction[0];                  // X "головы" змеи
            SnakeCordinates[0][1] += direction[1];                  // Y "головы" змеи



            if (CalculatingPlayGround[CenterOfCalcPlayGroundX + SnakeCordinates[0][0], CenterOfCalcPlayGroundY + SnakeCordinates[0][1]].Equals("+"))       // Если координаты головы змеи и еды совпадают
            {
                SnakeCordinates.Add(new int[2]);                    // Добавляем элемент змеи
                Game.GenerateFood();                                // Создаем новую еду

            }


            //TODO: проверка выхода с границ массива
            //TODO: проверка врезания головы змеи в тело змеи


            for (int i = 0; i < SnakeCordinates.Count; i++)
            {
                if (i < (SnakeCordinates.Count - 1))
                {
                    CalculatingPlayGround [CenterOfCalcPlayGroundX + SnakeCordinates[i][0], CenterOfCalcPlayGroundY + SnakeCordinates[i][1]] = "█";     // Закрашиваем поле где будет змея
                    ToDrawSnake(CenterOfCalcPlayGroundX + SnakeCordinates[i][0], CenterOfCalcPlayGroundY + SnakeCordinates[i][1]);

                }
                else
                {
                    CalculatingPlayGround [CenterOfCalcPlayGroundX + SnakeCordinates[i][0], CenterOfCalcPlayGroundY + SnakeCordinates[i][1]] = " ";     // Закрашиваем поле откуда змея ушла последний элемент
                    ToErase(CenterOfCalcPlayGroundX + SnakeCordinates[i][0], CenterOfCalcPlayGroundY + SnakeCordinates[i][1]);
                }
            }


        }

        public static int[] GetDirection (ConsoleKeyInfo pressedkey)   // Получаем координаты движения в зависимости от нажатой клавиши. 
        {
            Game.OldPressedKey = pressedkey;

            int[] direction = new int[2];

            if (pressedkey.Key == ConsoleKey.W || pressedkey.Key == ConsoleKey.UpArrow)
            {
                direction[0] = 0;   // X
                direction[1] = -1;  // Y - вверх
            }
            if (pressedkey.Key == ConsoleKey.D || pressedkey.Key == ConsoleKey.RightArrow)
            {
                direction[0] = 1;   // X
                direction[1] = 0;   // Y
            }
            if (pressedkey.Key == ConsoleKey.A || pressedkey.Key == ConsoleKey.LeftArrow)
            {
                direction[0] = -1;  // X
                direction[1] = 0;   // Y
            }
            if (pressedkey.Key == ConsoleKey.S || pressedkey.Key == ConsoleKey.DownArrow)
            {
                direction[0] = 0;   // X
                direction[1] = 1;   // Y - вниз 
            }

            return direction;

        }

        public static void SnakeAddFourElements()
        {
            SnakeCordinates.Add(new int[2]);
            SnakeCordinates.Add(new int[2]);
            SnakeCordinates.Add(new int[2]);
            SnakeCordinates.Add(new int[2]);
        }



    }



}

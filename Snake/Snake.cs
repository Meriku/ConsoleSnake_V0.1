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
            Game.OldPressedKey = pressedkey;

            ToDrawScore();            
            FirstTimeAddElements();     // Создание змейки первый раз в игре         
                    
            for (int n = SnakeCordinates.Count - 1; n >= 1; n--)    // Сохраняем в n максимальный индекс списка и идем от большего к меньшему
            {
                SnakeCordinates[n][0] = SnakeCordinates[n - 1][0];  // X 
                SnakeCordinates[n][1] = SnakeCordinates[n - 1][1];  // Y
            }

            SnakeCordinates[0][0] += GetDirection(pressedkey)[0];                  // X "головы" змеи
            SnakeCordinates[0][1] += GetDirection(pressedkey)[1];                  // Y "головы" змеи

            CheckForBorders();      // Проверка выхода с границ массива
            CheckForEat();          // Проверка пересечение змеи с едой 

            for (int j = 0; j < SnakeCordinates.Count; j++)
            {
                if (j < (SnakeCordinates.Count - 1))
                {                   
                    ToDrawSnake(SnakeCordinates[j][0], SnakeCordinates[j][1]);
                    CalculatingPlayGround[SnakeCordinates[j][0], SnakeCordinates[j][1]] = "█";     // Закрашиваем поле где будет змея
                }
                else
                {
                    ToErase(SnakeCordinates[j][0], SnakeCordinates[j][1]);
                    CalculatingPlayGround[SnakeCordinates[j][0], SnakeCordinates[j][1]] = " ";     // Закрашиваем поле откуда змея ушла 
                }
            }

            CheckHeadIntoSnake();   // Проверка врезания головы змеи в тело змеи

        }
        public static int[] GetDirection (ConsoleKeyInfo pressedkey)   // Получаем координаты движения в зависимости от нажатой клавиши. 
        {
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

        public static void CheckForEat()
        {
            if (CalculatingPlayGround[SnakeCordinates[0][0], SnakeCordinates[0][1]].Equals("+"))       // Если координаты головы змеи и еды совпадают
            {
                int[] tempcord = new int[2] { CalculatingPlayGround.GetLength(0) / 2, CalculatingPlayGround.GetLength(1) / 2 };
                SnakeCordinates.Add(tempcord);          // Добавляем элемент змеи
                Game.GenerateFood();                    // Создаем новую еду
            } 
        }

        public static void CheckForBorders()
        {     
            if (SnakeCordinates[0][0] < 1 || SnakeCordinates[0][0] > CalculatingPlayGround.GetLength(0)-2 || SnakeCordinates[0][1] < 1 || SnakeCordinates[0][1] > CalculatingPlayGround.GetLength(1) - 2)       // Если врезаемся в тело змеи или границы поля
            {
                Game.IsGameEnded = true;                // Завершаем игру
            }
        }

        public static void CheckHeadIntoSnake()
        {
            if (SnakeCordinates.Count >= 8)
            {      
                for (int t = 1; t < SnakeCordinates.Count - 1; t++)       // Последний элемент змеи существует только что бы закрашивать поле после змеи
                {
                    if ((SnakeCordinates[0][0] == SnakeCordinates[t][0])&&(SnakeCordinates[0][1] == SnakeCordinates[t][1]))       // Если врезаемся в тело змеи или границы поля
                    {
                        Game.IsGameEnded = true;        // Завершаем игру
                    }
                }
            }               
        }

        public static void FirstTimeAddElements()
        {    
            if (SnakeCordinates.Count < 8)
            {
                int[] tempcord = new int[2] { CalculatingPlayGround.GetLength(0) / 2, CalculatingPlayGround.GetLength(1) / 2 };
                SnakeCordinates.Add(tempcord);
            }         
        }
    }
}

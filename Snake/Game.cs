using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public static string[,] newPlayGround  = new string[49, 45];            // Массив игрового поля (двухмерный массив)

        public static List<int[]> newSnake  = new List<int[]>();                // Координаты нахождения змеи (список X1, Y1, X2, Y2...)

        public static bool PlayerTurn = false;

     

        public static bool IsKeyWASD (ConsoleKeyInfo key)                       // Метод, проверяющий что переданная клавиша - одна из разрешенных 
        {      

            if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool IsRightDirect (ConsoleKeyInfo newKey, string oldKey) //  Метод, проверяющий не захотел ли пользователь развернуться на 180 градусов (так нельзя) 
        {
            if ((newKey.Key == ConsoleKey.W || newKey.Key == ConsoleKey.UpArrow) && string.Equals(oldKey, "S"))
            {
                return false; // Если пользователь двигался вниз и хочет начать движение вверх
            }
            if ((newKey.Key == ConsoleKey.S || newKey.Key == ConsoleKey.DownArrow) && string.Equals(oldKey, "W"))
            {
                return false; // Если пользователь двигался вверх и хочет начать движение вниз
            }
            if ((newKey.Key == ConsoleKey.A || newKey.Key == ConsoleKey.LeftArrow) && string.Equals(oldKey, "D"))
            {
                return false; // Если пользователь двигался вправо и хочет начать движение влево
            }

            if ((newKey.Key == ConsoleKey.D || newKey.Key == ConsoleKey.RightArrow) && string.Equals(oldKey, "A"))
            {
                return false; // Если пользователь двигался влево и хочет начать движение вправо
            }
            else
            {
                return true;
            }
        }




    }




}

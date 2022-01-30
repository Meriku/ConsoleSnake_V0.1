using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public static string[,] newPlayGround  = new string[49, 45];    // Массив игрового поля (двухмерный массив)

        public static List<int[]> newSnake  = new List<int[]>();        // Координаты нахождения змеи (список X1, Y1, X2, Y2...)

        public static bool ready = true;


        public void DrawPlayGround(string[,] newPlayGround)
        {
            Console.Clear();

            int PlayGroundWidth = newPlayGround.GetLength(0);       // Ширина поля
            int PlayGroundHeight = newPlayGround.GetLength(1);      // Высота поля


            Console.Write("\n\n\n");                                // Пустое место сверху 

            for (int j = 0; j < PlayGroundHeight; j++)              // Рисуем в высоту 
            {
                Console.Write("\n");

                for (int i = 0; i < PlayGroundWidth; i++)           // Рисуем в ширину 
                {
                    if (i == 0) { Console.Write("\t\t\t"); }        // Отступ слева
                    Console.Write(newPlayGround[i, j]);

                }
            }

            Game.ready = true;


        }



    }




}

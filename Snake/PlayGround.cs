using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class PlayGround : Game
    {    
        public static void CreatePlayGround()
        {
            int PlayGroundWidth = CalculatingPlayGround.GetLength(0);       // Ширина поля
            int PlayGroundHeight = CalculatingPlayGround.GetLength(1);      // Высота поля

            for (int j = 0; j < PlayGroundHeight; j++)              // Высота
            {

                for (int i = 0; i < PlayGroundWidth; i++)           // Ширина
                {
                    if (i == 0 ||  j == 0 || j == PlayGroundHeight-1 || i == PlayGroundWidth - 1) 
                    {
                        CalculatingPlayGround[i, j] = "█";          // Границы игрового поля 
                        ToDrawBorders(i, j);

                    }
                    else
                    {
                        CalculatingPlayGround[i, j] = " ";          // Игровое поле
                    }
                }
            }
        }
    }
}

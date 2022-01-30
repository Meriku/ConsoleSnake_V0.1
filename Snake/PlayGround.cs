using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class PlayGround : Game
    {
      

        public void CreatePlayGround()
        {
            int PlayGroundWidth = newPlayGround.GetLength(0);      // Ширина поля
            int PlayGroundHeight = newPlayGround.GetLength(1);     // Высота поля


            for (int j = 0; j < PlayGroundHeight; j++)          // Рисуем в высоту 
            {

                for (int i = 0; i < PlayGroundWidth; i++)       // Рисуем в ширину 
                {
                    if (i == 0 || j == 0 || j == PlayGroundHeight-1 || i == PlayGroundWidth - 1)
                    {
                        newPlayGround[i, j] = "██";                // Границы               
                    }
                    else
                    {
                        newPlayGround[i, j] = "░░";                // Игровое поле               
                    }

                }
            }

        }


    }
}

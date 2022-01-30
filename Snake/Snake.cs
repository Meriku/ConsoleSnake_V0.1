using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : Game
    {
      
        public void Move(ConsoleKeyInfo pressedkey)     // Меняем положение змеи 
        {
            Game.ready = false;

            newSnake.Add(new int[2]);                   // Добавляем значение в список = второй элемент змеи
            newSnake.Add(new int[2]);                   // Добавляем значение в список = второй элемент змеи

            int[] direction = new int[2];
            
            if (pressedkey.Key == ConsoleKey.W || pressedkey.Key == ConsoleKey.UpArrow)
            {
                direction[0] = 0;   // X
                direction[1] = -1;   // Y
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
                direction[1] = 1;   // Y - увеличивается поскольку большие значения массива находятся внизу 
            }

            newSnake[1][0] = newSnake[0][0]; // Сохраняем значения X "головы" змеи которые сейчас изменим
            newSnake[1][1] = newSnake[0][1]; // Сохраняем значения Y "головы" змеи которые сейчас изменим


            newSnake[0][0] += direction[0]; // Меняем координаты X "головы" змеи
            newSnake[0][1] += direction[1]; // Меняем координаты Y "головы" змеи

            MoveSnake(newSnake);

        }


        public void MoveSnake(List<int[]> position) // Рисуем новое положение змеи
        {
            //TODO: проверка выхода с границ массива

            newPlayGround[24 + position[1][0], 22 + position[1][1]] = "░░"; // Закрашиваем поле откуда змея ушла
            newPlayGround[24 + position[0][0], 22 + position[0][1]] = "██"; // Закрашиваем поле где будет змея

            DrawPlayGround(newPlayGround);

        }



        public string SnakeToString()
        {
            string result = "";

            foreach (var item in newSnake)
            {
                result += $"\nX = {item[0].ToString()}, Y = {item[1].ToString()}";
            }

            return result;

        }





    }

   

}

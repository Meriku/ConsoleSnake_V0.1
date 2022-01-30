using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    

    public class Snake : Game
    {
        public string SnakeDirection;

        //TODO: создание в случайном месте еды для змейки, рост змейки

        public void Move(ConsoleKeyInfo pressedkey)     // Меняем положение змеи 
        {
            PlayerTurn = true;

            newSnake.Add(new int[2]);                   // Добавляем значение в список = элементы змеи
            newSnake.Add(new int[2]);                   
            newSnake.Add(new int[2]);
            newSnake.Add(new int[2]);
            newSnake.Add(new int[2]);
            newSnake.Add(new int[2]);                   // Последний элемент существует для того что бы перекрашивать в фоновый цвет "пиксели" после змейки 
                          

            int[] direction = new int[2];
            
            if (pressedkey.Key == ConsoleKey.W || pressedkey.Key == ConsoleKey.UpArrow)
            {
                SnakeDirection = "W";
                direction[0] = 0;   // X
                direction[1] = -1;   // Y
            }
            if (pressedkey.Key == ConsoleKey.D || pressedkey.Key == ConsoleKey.RightArrow)
            {
                SnakeDirection = "D";
                direction[0] = 1;   // X
                direction[1] = 0;   // Y
            }
            if (pressedkey.Key == ConsoleKey.A || pressedkey.Key == ConsoleKey.LeftArrow)
            {
                SnakeDirection = "A";
                direction[0] = -1;  // X
                direction[1] = 0;   // Y
            }
            if (pressedkey.Key == ConsoleKey.S || pressedkey.Key == ConsoleKey.DownArrow)
            {
                SnakeDirection = "S";
                direction[0] = 0;   // X
                direction[1] = 1;   // Y - увеличивается поскольку большие значения массива находятся внизу 
            }


            //TODO: Создать добавление новых элементов и изменение их координат через цикл или метод. То что сейчас - сугубо для теста. 


            newSnake[5][0] = newSnake[4][0]; 
            newSnake[5][1] = newSnake[4][1];

            newSnake[4][0] = newSnake[3][0]; 
            newSnake[4][1] = newSnake[3][1]; 

            newSnake[3][0] = newSnake[2][0]; // Сохраняем значения X и Y третьего элемента в четвертом элементе, перед изменением координат третьего элемента 
            newSnake[3][1] = newSnake[2][1]; 

            newSnake[2][0] = newSnake[1][0]; // Сохраняем значения X и Y второго элемента в третьем элементе, перед изменением координат второго элемента 
            newSnake[2][1] = newSnake[1][1]; 

            newSnake[1][0] = newSnake[0][0]; // Сохраняем значения X и Y головы змеи в втором её элементе, перед изменением координат головы змеи 
            newSnake[1][1] = newSnake[0][1]; 


            newSnake[0][0] += direction[0]; // Меняем координаты X "головы" змеи
            newSnake[0][1] += direction[1]; // Меняем координаты Y "головы" змеи


            MoveSnake(newSnake);

        }


        public void MoveSnake(List<int[]> position)                         // Рисуем новое положение змеи
        {

            //TODO: проверка выхода с границ массива


            newPlayGround[24 + position[5][0], 22 + position[5][1]] = "░░"; // Закрашиваем поле откуда змея ушла
            newPlayGround[24 + position[4][0], 22 + position[4][1]] = "██"; // Закрашиваем поле откуда змея ушла
            newPlayGround[24 + position[3][0], 22 + position[3][1]] = "██"; // Закрашиваем поле откуда змея ушла
            newPlayGround[24 + position[2][0], 22 + position[2][1]] = "██"; // Закрашиваем поле откуда змея ушла
            newPlayGround[24 + position[1][0], 22 + position[1][1]] = "██"; // 
            newPlayGround[24 + position[0][0], 22 + position[0][1]] = "██"; // Закрашиваем поле где будет змея

            PlayGround.DrawPlayGround();

        }



        public string SnakeToString()                                       // Вывод координат всех элементов змеи. 
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

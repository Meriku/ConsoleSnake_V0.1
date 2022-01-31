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

        //TODO: создание в случайном месте еды для змейки

        public void Move(ConsoleKeyInfo pressedkey)         
        {

            if (newSnake.Count < 4)                         // Создание змейки первый раз в игре
            {
                newSnake.Add(new int[2]);                   
                newSnake.Add(new int[2]);
                newSnake.Add(new int[2]);
                newSnake.Add(new int[2]);                    
            }

  
            for (int n = newSnake.Count-1; n >= 1; n--)     // Сохраняем в n максимальный индекс списка и идем от большего к меньшему
            {
                newSnake[n][0] = newSnake[n-1][0];          // X 
                newSnake[n][1] = newSnake[n-1][1];          // Y        
            }


            int[] direction = GetDirection(pressedkey);     // Получаем направление движения по переданному значению нажатой кнопки
              
            newSnake[0][0] += direction[0];                 // X "головы" змеи
            newSnake[0][1] += direction[1];                 // Y "головы" змеи

            MoveSnake(newSnake);                            // Передаем положения змеи для отрисовки

        }


        public void MoveSnake(List<int[]> position)       
        {

            //TODO: проверка выхода с границ массива
            //TODO: проверка врезания головы змеи в тело змеи

            for (int i = 0; i < newSnake.Count; i++)
            {
                if (i < (newSnake.Count - 1))
                {
                    newPlayGround[24 + position[i][0], 22 + position[i][1]] = "██";     // Закрашиваем поле где будет змея
                }
                else
                {
                    newPlayGround[24 + position[i][0], 22 + position[i][1]] = "  ";     // Закрашиваем поле откуда змея ушла последний элемент 
                }
            }          

            PlayGround.DrawPlayGround();                        // Рисуем новое положение змеи

        }



        public void EatAndGrow()                                // Рост змеи
        {

            newSnake.Add(new int[2]);                           // Добавляем новый элемент змеи

        }


        public int[] GetDirection (ConsoleKeyInfo pressedkey)   // Получаем координаты движения в зависимости от нажатой клавиши. 
        {

            int[] direction = new int[2];

            if (pressedkey.Key == ConsoleKey.W || pressedkey.Key == ConsoleKey.UpArrow)
            {
                SnakeDirection = "W";
                direction[0] = 0;   // X
                direction[1] = -1;  // Y - вверх
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
                direction[1] = 1;   // Y - вниз 
            }

            return direction;

        }




        public string SnakeToString()                           // Вывод координат всех элементов змеи. (Метод отладки)
        {
            string result = "";

            foreach (var item in newSnake)
            {
                result += $"\nX = {item[0]}, Y = {item[1]}";
            }

            return result;

        }





    }

   

}

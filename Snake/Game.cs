using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public static string[,] CalculatingPlayGround = new string[40, 40];         // Массив игрового поля (по факту будем выводить на консоль методом экстраполяции как на поле 80*40)

        public static List<int[]> SnakeCordinates = new List<int[]>();              // Змея (состоит из списка одномерных массивов - в каждом значения X,Y)

        public static ConsoleKeyInfo OldPressedKey;                                 // Временное хранилище для нажатой игроком кнопки

        public static bool IsStarted = false;


        public static bool IsKeyRightDirect (ConsoleKeyInfo newKey, ConsoleKeyInfo oldKey)  //  Метод, проверяющий не захотел ли пользователь развернуться на 180 градусов (так нельзя) 
                                                                                            //  Метод, не позволяющий двигаться быстрее нажимая клавишу движения в сторону в которую производится движение 
        {
            if ((newKey.Key == ConsoleKey.W || newKey.Key == ConsoleKey.UpArrow) && (oldKey.Key == ConsoleKey.S || oldKey.Key == ConsoleKey.DownArrow))
            {
                return false; // Если пользователь двигался вниз и хочет начать движение вверх
            }
            if ((newKey.Key == ConsoleKey.S || newKey.Key == ConsoleKey.DownArrow) && (oldKey.Key == ConsoleKey.W || oldKey.Key == ConsoleKey.UpArrow))
            {
                return false; // Если пользователь двигался вверх и хочет начать движение вниз
            }
            if ((newKey.Key == ConsoleKey.A || newKey.Key == ConsoleKey.LeftArrow) && (oldKey.Key == ConsoleKey.D || oldKey.Key == ConsoleKey.RightArrow))
            {
                return false; // Если пользователь двигался вправо и хочет начать движение влево
            }
            if ((newKey.Key == ConsoleKey.D || newKey.Key == ConsoleKey.RightArrow) && (oldKey.Key == ConsoleKey.A || oldKey.Key == ConsoleKey.LeftArrow))
            {
                return false; // Если пользователь двигался влево и хочет начать движение вправо
            }
            if ((newKey.Key == ConsoleKey.W || newKey.Key == ConsoleKey.UpArrow) && (oldKey.Key == ConsoleKey.W || oldKey.Key == ConsoleKey.UpArrow))
            {
                return false; // Повторное нажатие вверх 
            }
            if ((newKey.Key == ConsoleKey.S || newKey.Key == ConsoleKey.DownArrow) && (oldKey.Key == ConsoleKey.S || oldKey.Key == ConsoleKey.DownArrow))
            {
                return false; // Повторное нажатие вниз 
            }
            if ((newKey.Key == ConsoleKey.A || newKey.Key == ConsoleKey.LeftArrow) && (oldKey.Key == ConsoleKey.A || oldKey.Key == ConsoleKey.LeftArrow))
            {
                return false; // Повторное нажатие влево
            }
            if ((newKey.Key == ConsoleKey.D || newKey.Key == ConsoleKey.RightArrow) && (oldKey.Key == ConsoleKey.D || oldKey.Key == ConsoleKey.RightArrow))
            {
                return false; // Повторное нажатие вправо
            }
            else
            {
                return true;
            }
        }

        public static bool IsKeyWASD(ConsoleKeyInfo key)                        // Метод, проверяющий что переданная клавиша - одна из разрешенных 
        {
            return (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow);
        }



        public static void GenerateFood ()                                      // Генерация еды для змеи в случайном месте игрового поля
        {

            var rnd = new Random();
            int X = rnd.Next(2, CalculatingPlayGround.GetLength(0)-3);
            int Y = rnd.Next(2, CalculatingPlayGround.GetLength(1)-3);

            while (true)
            {
                if (CalculatingPlayGround[X, Y].Equals("█"))                    // Если случайные значения попадают в тело змеи - генерируем заново. 
                {
                    X = rnd.Next(2, CalculatingPlayGround.GetLength(0) - 3);
                    Y = rnd.Next(2, CalculatingPlayGround.GetLength(1) - 3);
                }
                else
                {
                    CalculatingPlayGround[X, Y] = "+";
                    ToDrawEat(X,Y);
                    break;
                }
            }        
        } 


        public static void ToDrawSnake(int X, int Y)
        {
            Y += 5;
            X += 5;
            Console.SetCursorPosition(X*2, Y);
            Console.Write("█");
            Console.SetCursorPosition(X*2+1, Y);
            Console.Write("█");
        }

        public static void ToDrawEat(int X, int Y)
        {
            Y += 5;
            X += 5;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(X * 2, Y);
            Console.Write("█");
            Console.SetCursorPosition(X * 2 + 1, Y);
            Console.Write("█");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ToDrawBorders (int X, int Y)
        {
            Y += 5;
            X += 5;
            if (X == 0)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("█");
                Console.SetCursorPosition(1, Y);
                Console.Write("█");
            }
            else
            {
                Console.SetCursorPosition(X*2, Y);
                Console.Write("█");
                Console.SetCursorPosition(X*2 + 1, Y);
                Console.Write("█");
            }

        }

        public static void ToDraw(int X, int Y, string text)
        {       
            Console.SetCursorPosition(X, Y);
            Console.Write(text);
        }

        
        public static void ToDrawScore ()
        {
            Console.SetCursorPosition(10, 2);
            Console.Write($"Score: {SnakeCordinates.Count-4}          ");
        }

        public static void ToErase(int X, int Y)
        {
            Y += 5;
            X += 5;
            Console.SetCursorPosition(X*2, Y);
            Console.Write(" ");
            Console.SetCursorPosition(X*2 + 1, Y);
            Console.Write(" ");
        }










    }




}

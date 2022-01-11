using System;
using System.Collections.Generic;
using System.Threading;
namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int x = 150;
            //drawing a game field frame
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(2, 20, '3');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(80, 25, 'O');
            Point food = foodGenerator.GenerateFood();
            food.Draw();

            while (true)
            {
                if (walls.isHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.Red;
                    score++;
                    Console.Beep();
                    x = x - 10;
                    
                }              
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(x);

            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }
        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("XDXDXDXDXDXDXDXDXDXDXDXDXDXD", xOffset, yOffset++);
            WriteText("     MÄNG LÄBI   ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText($"Sa skoorisid {score} punkti", xOffset + 2, yOffset++);
            WriteText("", xOffset + 1, yOffset++);
            WriteText("XDXDXDXDXDXDXDXDXDXDXDXDXDXD", xOffset, yOffset);
        }
        public static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }       
    }
}

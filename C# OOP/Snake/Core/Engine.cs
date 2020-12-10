namespace Snake.Core
{
    using Snake.Enums;
    using Snake.GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    public class Engine
    {
        private Direction direction;
        private readonly Point[] pointsOfDirections;

        private readonly Wall wall;
        private readonly Snake Snake;

        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.Snake = snake;
            this.sleepTime = 100;
            this.pointsOfDirections = new Point[4];
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if(Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = this.Snake
                    .IsMoving(this.pointsOfDirections[(int)this.direction]);

                if(!isMoving)
                {
                    this.AskUserForRestart();
                }

                sleepTime -= 0.05;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? Yes/No");
            Console.SetCursorPosition(leftX, topY + 1);

            string input = Console.ReadLine();

            if(input == "Yes")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void CreateDirections()
        {
            this.pointsOfDirections[0] = new Point(1, 0);
            this.pointsOfDirections[1] = new Point(-1, 0);
            this.pointsOfDirections[2] = new Point(0, 1);
            this.pointsOfDirections[3] = new Point(0, -1);
        }
    }
}

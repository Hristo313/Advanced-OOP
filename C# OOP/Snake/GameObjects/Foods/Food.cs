namespace Snake.GameObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;

            this.random = new Random();
        }

        public int FoodPoints { get; set; }

        public bool IsFoodPoint(Point snakeHead)     
           => this.LeftX == snakeHead.LeftX && this.TopY == snakeHead.TopY;      

        public void SetRandomPoints(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, wall.LeftX - 2);
            this.TopY = this.random.Next(2, wall.TopY - 2);

            bool isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOnSnake)
            {
                this.LeftX = this.random.Next(2, this.LeftX - 2);
                this.TopY = this.random.Next(2, this.TopY - 2);

                isPointOnSnake = snakeElements
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Green;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}

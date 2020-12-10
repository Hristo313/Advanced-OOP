namespace Snake.GameObjects
{
    using global::Snake.GameObjects.Foods;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Snake
    {
        private const char SNAKE_SYMBOL = '\u25CF';

        private int nextLeftX;
        private int nextTopY;

        private int foodIndex;

        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;

        public Snake(Wall wall)
        {
            this.wall = wall;

            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];

            this.foodIndex = RandomFoodNumber;

            this.GetFoods();
            this.CreateSnake();
        }

        public int RandomFoodNumber
            => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            Point snakeHead = this.snakeElements.Last();

            this.GetNextPoint(direction, snakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(p => p.LeftX == this.nextLeftX && p.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOnWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SNAKE_SYMBOL);

            if (this.foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        public void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPoints(this.snakeElements);        
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int topY = 0; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }

            this.foods[this.foodIndex].SetRandomPoints(this.snakeElements);
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodAsterisk(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }
    }
}

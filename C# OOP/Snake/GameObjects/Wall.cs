namespace Snake.GameObjects
{
    using System;

    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitializewallBorders();
        }

        public bool IsPointOnWall(Point snake)
        {
            return snake.LeftX == 0 || snake.LeftX == this.LeftX - 1
                || snake.TopY == 0 || snake.TopY == this.TopY;
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void InitializewallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }
    }
}

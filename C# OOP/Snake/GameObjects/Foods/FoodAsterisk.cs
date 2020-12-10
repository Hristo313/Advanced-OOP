namespace Snake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char FOOD_SYMBOL = '*';
        private const int POINTS = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, FOOD_SYMBOL, POINTS)
        {
        }
    }
}

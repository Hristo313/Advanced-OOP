namespace Snake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FOOD_SYMBOL = '#';
        private const int POINTS = 3;

        public FoodHash(Wall wall) 
            : base(wall, FOOD_SYMBOL, POINTS)
        {
        }
    }
}

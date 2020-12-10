namespace Snake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FOOD_SYMBOL = '$';
        private const int POINTS = 2;

        public FoodDollar(Wall wall) 
            : base(wall, FOOD_SYMBOL, POINTS)
        {
        }
    }
}

namespace Snake
{
    using Snake.Core;
    using Snake.GameObjects;
    using Snake.Utilities;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);

            string copyRightText = "Snake game";

            Console.SetCursorPosition(wall.LeftX - copyRightText.Length, wall.TopY + 1);
            Console.Write(copyRightText);

            string score = "Score: ";

            Console.SetCursorPosition(wall.LeftX - copyRightText.Length, wall.TopY + 2);
            Console.Write(score);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}

namespace CustomDoublyLinkedList
{
    using System;

    public class StratUp
    {
        public static void Main()
        {
            var list = new DoublyLinkedList<int>();

            for (int i = 1; i <= 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 1; i <= 10; i++)
            {
                list.AddLast(i);              
            }

            list.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                list.RemoveFirst();
            }

            list.ForEach(n => Console.Write(n + " "));

            int[] arr = list.ToArray();

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}

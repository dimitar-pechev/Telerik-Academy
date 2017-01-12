using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            var linkedList = new CustomLinkedList<int>();

            linkedList.Add(new ListItem<int>(1));
            linkedList.Add(new ListItem<int>(2));
            linkedList.Add(new ListItem<int>(3));

            Console.WriteLine(linkedList.First.Value);
            Console.WriteLine(linkedList.First.NextItem.Value);
            Console.WriteLine(linkedList.Last.Value);
        }
    }
}

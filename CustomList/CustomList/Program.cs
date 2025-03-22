namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            // Adding elements
            Console.WriteLine("Adding elements:");
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);

            PrintList(list);

            // Checking indexer
            Console.WriteLine($"Element at index 2: {list[2]}");

            // Removing an element
            Console.WriteLine("\nRemoving element 20:");
            list.Remove(20);
            PrintList(list);

            // Removing at index
            Console.WriteLine("\nRemoving element at index 1:");
            list.RemoveAt(1);
            PrintList(list);

            // Checking resizing
            Console.WriteLine("\nAdding more elements to trigger resizing:");
            list.Add(50);
            list.Add(60);
            list.Add(70);
            list.Add(80);
            list.Add(90);
            PrintList(list);

            // Checking Count and Capacity
            Console.WriteLine($"\nFinal Count: {list.Count}, Capacity: {list.Capacity}");
        }
        static void PrintList(CustomList<int> list)
        {
            Console.Write("List contents: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

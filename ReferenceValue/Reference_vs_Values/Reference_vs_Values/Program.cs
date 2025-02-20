namespace Reference_vs_Values
{
    internal class Program
    {
        public class PointClass
        {
            public int X;
            public int Y;

            public PointClass(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public struct PointStruct
        {
            public int X;
            public int Y;

            public PointStruct(int x,int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Example with Class");
            PointClass classPoint1 = new PointClass(100, 50);
            PointClass classPoint2 = classPoint1;
            Console.WriteLine($"Before changes: \n" +
                $"Point1 X = {classPoint1.X}, Point1 Y = {classPoint1.Y}, \n" +
                $"Point2 X = {classPoint2.X}, Point2 Y = {classPoint2.Y}");
            classPoint2.X = 200;
            classPoint2.Y = 1;
            Console.WriteLine($"After changes: \n" +
                $"Point1 X = {classPoint1.X}, Point1 Y = {classPoint1.Y}, \n" +
                $"Point2 X = {classPoint2.X}, Point2 Y = {classPoint2.Y}");

            Console.WriteLine("===============================================================================");

            Console.WriteLine("Example with Struct");
            PointStruct structPoint1 = new PointStruct(100, 50);
            PointStruct structPoint2 = structPoint1;
            Console.WriteLine($"Before changes: \n" +
                $"Point1 X = {structPoint1.X}, Point1 Y = {structPoint1.Y}, \n" +
                $"Point2 X = {structPoint2.X}, Point2 Y = {structPoint2.Y}");
            structPoint2.X = 200;
            structPoint2.Y = 1;
            Console.WriteLine($"After changes: \n" +
                $"Point1 X = {structPoint1.X}, Point1 Y = {structPoint1.Y}, \n" +
                $"Point2 X = {structPoint2.X}, Point2 Y = {structPoint2.Y}");

        }
    }
}

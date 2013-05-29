namespace RotatingWalk
{
    using System;

    public class RotatingWalkExample
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(8);
            matrix.Traverse();

            Console.WriteLine(matrix.ToString());
        }
    }
}

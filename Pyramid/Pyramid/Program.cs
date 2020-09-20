using System;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"..\..\..\input.txt");
            //string text = "1\n8 9\n1 5 9\n4 5 2 3";
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid(text);
            var maxPath = string.Join(", ", pyramid.GetMaxPath());
            Console.WriteLine("Max sum: " + pyramid.GetMaxSum());
            Console.WriteLine("Path: " + maxPath);

            Console.WriteLine();
            Console.WriteLine("If you want to run with another pyramid, change input.txt file.");
        }
    }
}

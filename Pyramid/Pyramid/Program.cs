using System;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"..\..\..\input.txt");
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid(text);
            var maxPath = string.Join(", ", pyramid.GetMaxPath());
            Console.WriteLine("Max sum: " + pyramid.GetMaxSum());
            Console.WriteLine("Path: " + maxPath);
        }
    }
}

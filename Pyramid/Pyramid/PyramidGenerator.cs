using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    class PyramidGenerator
    {
        // TODO: make test class for PyramidGenerator

        static void Main(string[] args)
        {
            var p = new PyramidGenerator();
            p.GetNewPyramid("1\n8 9\n1 5 9\n4 5 2 3");
        }
        public Pyramid GetNewPyramid(string inputString)
        {
            var valuesInLines = StringToList(inputString);
            // PrintList(valuesInLines);
            var root = BuildPyramids(valuesInLines);
            return root;
        }

        private Pyramid BuildPyramids(List<string[]> valuesInLines)
        {
            var pyramidsWithValues = BuildPyramidsWithValues(valuesInLines);
            ConnectChildrens(pyramidsWithValues);
            // PrintPyramids(pyramidsWithValues);
            return pyramidsWithValues[0][0];
        }

        private void PrintPyramids(List<List<Pyramid>> pyramidsWithValues)
        {
            foreach (var line in pyramidsWithValues)
            {
                foreach (var p in line)
                {
                    var children = p.GetChildren();
                    if (children != null)
                    {
                        foreach (var child in children)
                        {
                            Console.Write(child.GetValue() + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private void ConnectChildrens(List<List<Pyramid>> pyramidsWithValues)
        {
            for (int row = 0; row < pyramidsWithValues.Count-1; row++)
            {       
                var line = pyramidsWithValues[row];
                for (int col = 0; col < line.Count; col++)
                {
                    var children = new List<Pyramid>();
                    children.Add(pyramidsWithValues[row + 1][col]);
                    children.Add(pyramidsWithValues[row + 1][col + 1]);
                    var currentPyramid = line[col];
                    currentPyramid.SetChildren(children);
                }
            }
        }

        private List<List<Pyramid>> BuildPyramidsWithValues(List<string[]> valuesInLines)
        {
            var pyramidsWithValues = new List<List<Pyramid>>();
            foreach (var line in valuesInLines)
            {
                var pyramids = new List<Pyramid>();
                foreach (var value in line)
                {
                    var p = new Pyramid(Int32.Parse(value));
                    pyramids.Add(p);
                }
                pyramidsWithValues.Add(pyramids);
            }

            return pyramidsWithValues;
        }

        private List<string[]> StringToList(string inputString)
        {
            var lines = inputString.Split("\n");
            var valuesInLines = new List<string[]>();
            foreach (var line in lines)
            {
                var valuesInLine = line.Split(" ");
                valuesInLines.Add(valuesInLine);
            }

            return valuesInLines;
        }

        private void PrintList(List<string[]> list)
        {
            foreach (var v in list)
            {
                foreach (var s in v)
                {
                    Console.Write(s.ToString() + " ");

                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    public class PyramidGenerator
    {
        // TODO: make test class for PyramidGenerator

        public Pyramid GetNewPyramid(string inputString)
        {
            var valuesInLines = StringToList(inputString);
            var root = BuildPyramids(valuesInLines);
            return root;
        }

        private Pyramid BuildPyramids(List<string[]> valuesInLines)
        {
            var pyramidsWithValues = BuildPyramidsWithValues(valuesInLines); // Instantiate pyramid objects only with values first, to prevent having 2 pyramid instances for a same value.
            ConnectChildrens(pyramidsWithValues);
            return pyramidsWithValues[0][0];
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
    }
}

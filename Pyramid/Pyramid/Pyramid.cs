using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    public class Pyramid
    {
        private int value; // in C# private instance variables naming starts with _. _value
        private List<Pyramid> children;
        // maybe I'll just use List<List<int>>...

        public Pyramid(int value, List<Pyramid> children)
        {
            this.value = value;
            this.children = children;
        }
        public int FindMaxSum()
        {
            throw new NotImplementedException();
        }
    }
}

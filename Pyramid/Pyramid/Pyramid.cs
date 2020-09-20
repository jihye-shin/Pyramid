using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    public class Pyramid
    {
        private int value; // in C# private instance variables naming starts with _. _value
        private List<Pyramid> children;

        public Pyramid(int value)
        {
            this.value = value;
            this.children = null;
        }
        public int FindMaxSum()
        {
            throw new NotImplementedException();
        }

        public List<Pyramid> GetChildren()
        {
            return children;
        }
        public void SetChildren(List<Pyramid> children)
        {
            this.children = children;
        }

        public int GetValue()
        {
            return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    public class Pyramid
    {
        private int value; // in C# private instance variables naming starts with _. _value
        private List<Pyramid> children;
        private int maxSum;
        private List<int> maxPath;

        public Pyramid(int value)
        {
            this.value = value;
            this.children = null;
            this.maxSum = Int32.MinValue;
            this.maxPath = null;
        }
        public int GetMaxSum()
        {
            if (maxSum != Int32.MinValue)
            {
                return maxSum;
            }
            else
            {
                FindMaxSumAndPath_rec();
                return maxSum;
            }
        }

        public List<int> GetMaxPath() // Should it be List<int> or List<Pyramid>?
        {
            if (maxPath != null)
            {
                return maxPath;
            }
            else
            {
                FindMaxSumAndPath_rec();
                return maxPath;
            }
        }

        private void FindMaxSumAndPath_rec()
        {
            
        }

        private int FindMaxSum_rec(int valueInParent)
        {
            if (!hasChildren())
            {
                return this.value;
            }
            else
            {
                int maxSumInChildren = Int32.MinValue;
                foreach (var child in this.children)
                {
                    maxSumInChildren = Math.Max(maxSumInChildren, FindMaxSum_rec(child.value));
                }

                return this.value + maxSumInChildren;
            }
        }

        private bool hasChildren()
        {
            return this.children != null;
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

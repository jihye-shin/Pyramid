using System;
using System.Collections.Generic;
using System.Text;

namespace Pyramid
{
    public class Pyramid
    {
        private int value;
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
                maxSum = FindMaxSumAndPath_rec(value);
                return maxSum;
            }
        }

        public List<int> GetMaxPath() // Should it return List<int> or List<Pyramid>?
        {
            if (maxPath != null)
            {
                return maxPath;
            }
            else
            {
                maxSum = FindMaxSumAndPath_rec(value);
                return maxPath;
            }
        }

        private int FindMaxSumAndPath_rec(int valueInParent)
        {
            if (!HasChildren())
            {
                this.maxPath = new List<int>() {this.value};
                return valueInParent;
            }
            else
            {
                var maxSumInChildren = Int32.MinValue;
                var maxPathInChildren = new List<int>();
                foreach (var child in this.children)
                {
                    if (valueInParent % 2 != child.value % 2)
                    {
                        var currentChildMaxSum = child.FindMaxSumAndPath_rec(child.value);
                        if (currentChildMaxSum > maxSumInChildren)
                        {
                            maxSumInChildren = currentChildMaxSum;
                            maxPathInChildren = child.maxPath;
                        }
                        maxSumInChildren = Math.Max(maxSumInChildren, child.FindMaxSumAndPath_rec(child.value));
                    }
                }

                maxPathInChildren.Insert(0, this.value);
                this.maxPath = maxPathInChildren;

                return valueInParent + maxSumInChildren;
            }
        }

        private bool HasChildren()
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

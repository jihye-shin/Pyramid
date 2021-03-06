using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using FluentAssertions;
using Xunit;

namespace Pyramid.Test
{
    public class PyramidTest
    {
        [Fact]
        public void GIVEN_1Pyramid_WHEN_GetMaxSum_THEN_GiveValueInPyramid()
        {
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("1");
            var maxSum = pyramid.GetMaxSum();
            maxSum.Should().Be(1, because: "The value in Pyramid is 1");
            var maxPath = pyramid.GetMaxPath();
            maxPath.Should().BeEquivalentTo(new List<int>() {1});
        }

        [Fact]
        public void GIVEN_2PathWithEqualSum_WHEN_GetMaxSum_THEN_GiveSumFrom1stPath()
        {
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("1\n8 9\n1 5 9\n6 5 2 3");
            var maxSum = pyramid.GetMaxSum();
            maxSum.Should().Be(16, because: "1-8-1-6 and 1-8-5-2 both gives 16 but 1-8-1-6 comes first");
            var maxPath = pyramid.GetMaxPath();
            maxPath.Should().BeEquivalentTo(new List<int>() { 1,8,1,6 });
        }

        [Fact]
        public void GIVEN_OddValueInRoot_WHEN_GetMaxSum_THEN_GiveMaxSum()
        {
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("1\n8 9\n1 5 9\n4 5 2 3");
            var maxSum = pyramid.GetMaxSum();
            maxSum.Should().Be(16, because: "1-8-5-2 gives 16");
            var maxPath = pyramid.GetMaxPath();
            maxPath.Should().BeEquivalentTo(new List<int>() { 1, 8, 5, 2 });
        }

        [Fact]
        public void GIVEN_EvenValueInRoot_WHEN_GetMaxSum_THEN_GiveMaxSum()
        {
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("0\n8 9\n2 4 9\n4 5 2 3");
            var maxSum = pyramid.GetMaxSum();
            maxSum.Should().Be(18, because: "0-9-4-5 gives 18");
            var maxPath = pyramid.GetMaxPath();
            maxPath.Should().BeEquivalentTo(new List<int>() { 0, 9, 4, 5 });
        }
    }
}

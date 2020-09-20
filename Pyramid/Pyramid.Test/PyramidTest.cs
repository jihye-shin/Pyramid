using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using FluentAssertions;
using Xunit;

namespace Pyramid.Test
{
    public class PyramidTest
    {   // TODO: implement tests for GetMaxPath()

        [Fact]
        public void GIVEN_1Pyramid_WHEN_GetMaxSum_THEN_GiveValueInPyramid()
        {
            // input: 1
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("1");
            var result = pyramid.GetMaxSum();
            result.Should().Be(1, because: "The value in Pyramid is 1");
        }

        [Fact]
        public void GIVEN_2PathWithEqualSum_WHEN_GetMaxSum_THEN_GiveSumFrom1stPath()
        {
            // input: 1\n8 9\n1 5 9\n6 5 2 3
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("1\n8 9\n1 5 9\n6 5 2 3");
            var result = pyramid.GetMaxSum();
            result.Should().Be(16, because: "1-8-1-6 and 1-8-5-2 both gives 16 but 1-8-1-6 comes first");
        }

        [Fact]
        public void GIVEN_OddValueInRoot_WHEN_GetMaxSum_THEN_GiveMaxSum()
        {
            // input: 1\n8 9\n1 5 9\n4 5 2 3
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("1\n8 9\n1 5 9\n4 5 2 3");
            var result = pyramid.GetMaxSum();
            result.Should().Be(16, because: "1-8-5-2 gives 16");
        }

        [Fact]
        public void GIVEN_EvenValueInRoot_WHEN_GetMaxSum_THEN_GiveMaxSum()
        {
            // input: 0\n8 9\n2 5 9\n4 5 2 3
            var pg = new PyramidGenerator();
            var pyramid = pg.GetNewPyramid("0\n8 9\n2 5 9\n4 5 2 3");
            var result = pyramid.GetMaxSum();
            result.Should().Be(16, because: "0-9-2-5 gives 16");
        }
    }
}

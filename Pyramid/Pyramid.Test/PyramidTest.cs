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
        public void Test1() // TODO: change method name. GIVEN_ABanana/WHEN/MonkeyEats/THEN/ErrorIsThrown
        {
            // input: 1
            Pyramid p = new Pyramid(1, new List<Pyramid>()); // instantiate with input
            var result = p.FindMaxSum();
            result.Should().Be(1);
        }

        [Fact]
        public void Test2() // TODO: change method name. GIVEN_ABanana/WHEN/MonkeyEats/THEN/ErrorIsThrown
        {
            // input: 1
            Pyramid p = new Pyramid(1, new List<Pyramid>() { new Pyramid(), new Pyramid() }); // instantiate with input
            var result = p.FindMaxSum();
            result.Should().Be(1);
        }
    }
}

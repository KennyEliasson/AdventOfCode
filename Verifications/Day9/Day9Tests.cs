using System;
using System.IO;
using System.Linq;
using Solutions.Day9;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day9
{
    public class Day9Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day9Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Fact]
        public void Task1_Example()
        {
            var numbers = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";
            var xmas = new Xmas();
            var result = xmas.FindFirstNumberThatNotMatchesPremable(numbers.Split(Environment.NewLine).Select(long.Parse).ToList(), 5);
            
            Assert.Equal(127, result);
}

        [Fact]
        public void Task1()
        {
            var numbers = File.ReadAllLines("Day9/input.txt").Select(long.Parse).ToList();
           var xmas = new Xmas();
           var result = xmas.FindFirstNumberThatNotMatchesPremable(numbers, 25);
           
           _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2_Example()
        {
            var numbers = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";
            var xmas = new Xmas();
            var result = xmas.FindRangeThatMatches(numbers.Split(Environment.NewLine).Select(long.Parse).ToList(), 127);
           
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2()
        {
            var numbers = File.ReadAllLines("Day9/input.txt").Select(long.Parse).ToList();
            var xmas = new Xmas();
            var result = xmas.FindRangeThatMatches(numbers, 25918798);
           
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
    } 
}
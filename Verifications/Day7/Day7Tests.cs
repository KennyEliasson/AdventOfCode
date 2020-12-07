using System;
using System.IO;
using System.Linq;
using Solutions.Day7;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day7
{
    public class Day7Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day7Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1()
        {
            var luggageRules = File.ReadAllLines("Day7/input.txt").ToList();
            
            var luggageProcessing = new LuggageProcessing(luggageRules);
            var result = luggageProcessing.FindLuggagesThatCanHaveKey("shiny gold");

            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2()
        {
            var luggageRules = File.ReadAllLines("Day7/input.txt").ToList();
            
            var luggageProcessing = new LuggageProcessing(luggageRules);
            var result = luggageProcessing.FindOutHowManyLuggages("shiny gold");

            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }

        [Fact]
        public void Task2Example()
        {
            var input = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";
            
            var luggageProcessing = new LuggageProcessing(input.Split(Environment.NewLine).ToList());
            var result = luggageProcessing.FindOutHowManyLuggages("shiny gold");
            
            Assert.Equal(126, result);
        }
    }
}
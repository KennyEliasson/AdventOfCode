using System;
using System.IO;
using System.Linq;
using Solutions.Day7;
using Solutions.Day8;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day8
{
    public class Day8Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day8Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1()
        {
            var bootInstructions = File.ReadAllLines("Day8/input.txt").ToList();
            
            var bootLoader = new Bootloader();
            bootLoader.Load(bootInstructions);
            var state = bootLoader.Execute();

            _outputHelper.WriteLine($"The result is {state.Accumulator.ToString()}");
        }
        
        [Fact]
        public void Task2()
        {
            var bootInstructions = File.ReadAllLines("Day8/input.txt").ToList();
            
            var bootLoader = new Bootloader();
            bootLoader.Load(bootInstructions);
            var state = bootLoader.FixProgram();

            _outputHelper.WriteLine($"The result is {state.Accumulator.ToString()}");
        }
    }
}
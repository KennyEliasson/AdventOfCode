using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solutions.Day5;
using Solutions.Day6;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day6
{
    public class Day6Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day6Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1()
        {
            var answers = File.ReadAllLines("Day6/input.txt").ToList();
            
            var customs = new Customs(answers);
            var result = customs.CountTotalUniqueAnswers();
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");

        }
        
        [Fact]
        public void Task2()
        {
            var answers = File.ReadAllLines("Day6/input.txt").ToList();
            
            var customs = new Customs(answers);
            var result = customs.CountAllSameAnswerPerGroup();
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");

        }
    }
}
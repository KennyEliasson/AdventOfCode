using System;
using System.IO;
using System.Linq;
using Solutions;
using Xunit;
using Xunit.Abstractions;

namespace Verifications
{
    public class Day1Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day1Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1()
        {
            var expenses = File.ReadAllLines("Day1/input.txt").Select(x => Convert.ToInt32(x)).ToList();
            var expenseReport = new ExpenseReport(expenses);
            
            var (a, b) = expenseReport.FindTwoNumbersMatchingSum(2020);

            var result = a * b;
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2()
        {
            var expenses = File.ReadAllLines("Day1/input.txt").Select(x => Convert.ToInt32(x)).ToList();
            var expenseReport = new ExpenseReport(expenses);
            
            var (a, b, c) = expenseReport.FindThreeNumbersMatchingSum(2020);

            var result = a * b * c;
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
    }
}
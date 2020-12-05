using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solutions.Day5;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day5
{
    public class Day5Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day5Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void Day5_Task1_Examples(string boardingPass, int expected)
        {
            var result = new BinaryBoarding().FindSeatIndex(boardingPass);
            Assert.Equal(expected, result);
        }
        
        
        [Fact]
        public void Day5_Task1()
        {
            var binaryBoarding = new BinaryBoarding();

            var seatIds = new List<int>();
            var boardingPasses = File.ReadAllLines("Day5/input.txt").ToList();

            foreach (var boardingPass in boardingPasses)
            {
                seatIds.Add(binaryBoarding.FindSeatIndex(boardingPass));
            }


            var result = seatIds.Max();
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Day5_Task2()
        {
            var binaryBoarding = new BinaryBoarding();
            var boardingPasses = File.ReadAllLines("Day5/input.txt").ToList();

            var plane = new Plane();

            foreach (var boardingPass in boardingPasses)
            {
                plane.AddOccupiedSeat(binaryBoarding.FindSeat(boardingPass));
            }
            
            var availableSeat = plane.FindAvailableSeat();
            var result = binaryBoarding.SeatIndex(availableSeat.rowIndex, availableSeat.seatIndex);

            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
    }

   
}
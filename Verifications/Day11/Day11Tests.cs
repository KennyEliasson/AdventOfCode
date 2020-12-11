using System;
using System.IO;
using System.Linq;
using Solutions.Day11;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day11
{
    public class Day11Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day11Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Fact]
        public void Task1_Example()
        {
            var example = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL".Split(Environment.NewLine);
            
            
            var seatMap = new SeatMap<AdjacentPosition>(example);
            var f = seatMap.Map;
            
            
            var result = seatMap.FindOccupiedSeatsWhenNoMoreDifferencesCanBeMade();
            
            Assert.Equal(37, result);
        }
        
        [Fact]
        public void Task1()
        { 
            var lines = File.ReadAllLines("Day11/input.txt").ToList();
           var seatMap = new SeatMap<AdjacentPosition>(lines);
            
            
           var result = seatMap.FindOccupiedSeatsWhenNoMoreDifferencesCanBeMade();
            
           _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2()
        { 
            var lines = File.ReadAllLines("Day11/input.txt").ToList();
            var seatMap = new SeatMap<DirectionPosition>(lines);
            
            var result = seatMap.FindOccupiedSeatsWhenNoMoreDifferencesCanBeMade();
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2_Example()
        {
            var example = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL".Split(Environment.NewLine);
            
            var seatMap = new SeatMap<DirectionPosition>(example);

            var result = seatMap.FindOccupiedSeatsWhenNoMoreDifferencesCanBeMade();
            
            Assert.Equal(26, result);
        }
    } 
}
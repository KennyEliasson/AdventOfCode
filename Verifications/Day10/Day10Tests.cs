using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solutions.Day10;
using Solutions.Day9;
using Xunit;
using Xunit.Abstractions;

namespace Verifications.Day10
{
    public class Day10Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day10Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Fact]
        public void Task1_Example()
        {
            var adapters = new List<int> {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };
            
            var chargingAdapters = new ChargingAdapters();
            var differences = chargingAdapters.CalculateAdapterDifferences(adapters);

            Assert.Equal(7, differences.Count(x => x == 1));
            Assert.Equal(5, differences.Count(x => x == 3));
        }
        
        [Fact]
        public void Task1_Example_2()
        {
            var adapters = new List<int> {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };
            
            var chargingAdapters = new ChargingAdapters();
            var differences = chargingAdapters.CalculateAdapterDifferences(adapters);

            Assert.Equal(22, differences.Count(x => x == 1));
            Assert.Equal(10, differences.Count(x => x == 3));
        }   

        [Fact]
        public void Task1()
        {
            var adapters = File.ReadAllLines("Day10/input.txt").Select(int.Parse).ToList();
            var chargingAdapters = new ChargingAdapters();
            var differences = chargingAdapters.CalculateAdapterDifferences(adapters);

            var oneDiff = differences.Count(x => x == 1);
            var threeDiff = differences.Count(x => x == 3);

            var result = oneDiff * threeDiff;
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2_Example1()
        {
            var adapters = new List<int> {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };
            
            var chargingAdapters = new ChargingAdapters();
            var possibilities = chargingAdapters.CalculatePossibilities(adapters);
            
            Assert.Equal(8, possibilities);
        }
        
        [Fact]
        public void Task2_Example_2()
        {
            var adapters = new List<int> {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };
            
            var chargingAdapters = new ChargingAdapters();
            var possibilities = chargingAdapters.CalculatePossibilities(adapters);

            Assert.Equal(19208 , possibilities);
        }  
        
        [Fact]
        public void Task2()
        {
            var adapters = File.ReadAllLines("Day10/input.txt").Select(int.Parse).ToList();
            var chargingAdapters = new ChargingAdapters();
            var possibilities = chargingAdapters.CalculatePossibilities(adapters);

           
            _outputHelper.WriteLine($"The result is {possibilities.ToString()}");
        }
        
    } 
}
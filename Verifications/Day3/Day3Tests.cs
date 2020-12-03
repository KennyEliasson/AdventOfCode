using System.IO;
using System.Linq;
using Solutions;
using Xunit;
using Xunit.Abstractions;

namespace Verifications
{
    public class Day3Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day3Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1()
        {
            var slopeMap = File.ReadAllLines("Day3/input.txt").ToList();
            var slope = new SlopeCalculator(slopeMap);

            var result = slope.Ski(1, 3);
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }

        [Fact]
        public void Task1_Test()
        {
            var map = 
@"
.#...#.......#...#...#.#.#.....
####.....#.#..#...#...........#
.....#...........#......#....#.
......#..#......#.#..#...##.#.#
............#......#...........
...........#.#.#....#.......##.
....#.......#..............#...
........##...#.#.....##...##.#.
.#.#.....##................##..
.##................##..#...##..
....#...###...##.........#....#
.##......#.........#...........
...#.#.#....#....#...#...##...#
..#....##...#..#.#..#.....#.#..";

            var slopeMap = map.Split("\r\n").ToList();
            slopeMap = slopeMap.GetRange(1, 14);

            var slope = new SlopeCalculator(slopeMap);
            
            var trees = slope.Ski(1, 3);
        }
        
        [Fact]
        public void Task2()
        {
            var slopeMap = File.ReadAllLines("Day3/input.txt").ToList();
            var slope = new SlopeCalculator(slopeMap);
            
            var a = slope.Ski(1, 1);
            var b = slope.Ski(1, 3);
            var c = slope.Ski(1, 5);
            var d = slope.Ski(1, 7);
            var e = slope.Ski(2, 1);

            long result = (long)a * b * c * d * e;
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }

        
    }
}
using System.IO;
using System.Linq;
using Solutions;
using Solutions.Day4;
using Xunit;
using Xunit.Abstractions;

namespace Verifications
{
    public class Day4Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day4Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1_Tests()
        {
            var input = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";
            
            var passportInput = input.Split("\r\n").ToList();
            var passportValidation = new PassportValidation<SimplePassport>(passportInput);

            var result = passportValidation.Validate();
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }

        [Fact]
        public void Task1()
        {
            var passportInput = File.ReadAllLines("Day4/input.txt").ToList();
            var passportValidation = new PassportValidation<SimplePassport>(passportInput);

            var result = passportValidation.Validate();
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
        
        [Fact]
        public void Task2()
        {
            var passportInput = File.ReadAllLines("Day4/input.txt").ToList();
            var passportValidation = new PassportValidation<AdvancedPassport>(passportInput);

            var result = passportValidation.Validate();
            
            _outputHelper.WriteLine($"The result is {result.ToString()}");
        }
 
    }
}
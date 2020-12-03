using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solutions;
using Xunit;
using Xunit.Abstractions;

namespace Verifications
{
    public class Day2Tests
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day2Tests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Task1()
        {
            var passwordWithPoliciesInput = File.ReadAllLines("Day2/input.txt").ToList();
            var policyChecker = new PasswordPolicyChecker(passwordWithPoliciesInput);
            
            var (validPasswords, invalidPasswords) = policyChecker.ExecuteOccurencePolicy();

            _outputHelper.WriteLine($"The result is {validPasswords.ToString()}");
        }

        [Fact]
        public void Task2_Test()
        {
            var policyChecker = new PasswordPolicyChecker(new List<string>()
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            });
            
            Assert.Equal(1, policyChecker.ExecutePositionPolicy());
        }
        
        [Fact]
        public void Task2()
        {
            var passwordWithPoliciesInput = File.ReadAllLines("Day2/input.txt").ToList();
            var policyChecker = new PasswordPolicyChecker(passwordWithPoliciesInput);
            
            var validPasswords = policyChecker.ExecutePositionPolicy();
            
            _outputHelper.WriteLine($"The result is {validPasswords.ToString()}");
        }
    }
}
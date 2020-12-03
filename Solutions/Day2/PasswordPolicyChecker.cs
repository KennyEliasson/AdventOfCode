using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solutions
{
    public class PasswordPolicyChecker
    {
        private readonly List<string> _passwordInput;
        private readonly Regex _policyRegex = new Regex("(\\d*)-(\\d*) (\\w): (\\w*)", RegexOptions.Compiled);

        public PasswordPolicyChecker(List<string> passwordInput)
        {
            _passwordInput = passwordInput;
        }

        public int ExecutePositionPolicy()
        {
            var validPasswords = 0;

            foreach (var input in _passwordInput)
            {
                var (policyPositionOne, policyPositionTwo, policyLetter, password) = PolicyData(input);

                var passwordCharArray = password.ToCharArray();
                var charAtPositionOne = passwordCharArray[policyPositionOne-1];
                var charAtPositionTwo = passwordCharArray[policyPositionTwo-1];

                if (charAtPositionOne == policyLetter && charAtPositionTwo == policyLetter) {
                    continue;
                }

                if (charAtPositionOne == policyLetter || charAtPositionTwo == policyLetter) {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        public (int validPasswords, int invalidPassword) ExecuteOccurencePolicy()
        {
            var validPasswords = 0;
            var invalidPassword = 0;
            
            foreach (var input in _passwordInput)
            {
                var (policyMinOccurences, policyMaxOccurences, policyLetter, password) = PolicyData(input);

                var policyLetterCount = password.Count(x => x == policyLetter);

                if (policyLetterCount >= policyMinOccurences && policyLetterCount <= policyMaxOccurences) {
                    validPasswords++;
                } else {
                    invalidPassword++;
                }
            }

            return (validPasswords, invalidPassword);
        }

        private (int policyMinOccurences, int policyMaxOccurences, char policyLetter, string password) PolicyData(string input)
        {
            var matches = _policyRegex.Match(input);

            var policyMinOccurences = int.Parse(matches.Groups[1].Value);
            var policyMaxOccurences = int.Parse(matches.Groups[2].Value);
            var policyLetter = matches.Groups[3].Value.ToCharArray()[0];
            var password = matches.Groups[4].Value;
            return (policyMinOccurences, policyMaxOccurences, policyLetter, password);
        }
    }
}
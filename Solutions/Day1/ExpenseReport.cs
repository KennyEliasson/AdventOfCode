using System.Collections.Generic;

namespace Solutions
{
    public class ExpenseReport
    {
        private readonly List<int> _expenses;

        public ExpenseReport(List<int> expenses)
        {
            _expenses = expenses;
        }

        public (int, int) FindTwoNumbersMatchingSum(int sum)
        {
            for (int i = 0; i < _expenses.Count-1; i++)
            {
                var current = _expenses[i];
                for (int j = 0; j < _expenses.Count-1; j++)
                {
                    if(i == j)
                        continue;

                    var testAgainst = _expenses[j];

                    if (current + testAgainst == sum)
                    {
                        return (current, testAgainst);
                    }
                }
            }

            return (0, 0);
        }
        
        public (int, int, int) FindThreeNumbersMatchingSum(int sum)
        {
            for (int i = 0; i < _expenses.Count-1; i++)
            {
                var current = _expenses[i];
                for (int j = 0; j < _expenses.Count-1; j++)
                {
                    var testAgainst = _expenses[j];
                    
                    if(current+testAgainst > sum)
                        continue;

                    for (int k = 0; k < _expenses.Count - 1; k++)
                    {
                        var testAgainstTwo = _expenses[k];
                        if (current + testAgainst + testAgainstTwo == sum)
                        {
                            return (current, testAgainst, testAgainstTwo);
                        }
                        
                    }
                }
            }

            return (0, 0, 0);
        }
    }
}
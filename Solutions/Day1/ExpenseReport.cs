using System;
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
            for (int leftTermIndex = 0; leftTermIndex < _expenses.Count-1; leftTermIndex++)
            {
                var leftTerm = _expenses[leftTermIndex];
                for (int rightTermIndex = 0; rightTermIndex < _expenses.Count-1; rightTermIndex++)
                {
                    if(leftTermIndex == rightTermIndex)
                        continue;

                    var rightTerm = _expenses[rightTermIndex];

                    if (leftTerm + rightTerm == sum)
                    {
                        return (leftTerm, rightTerm);
                    }
                }
            }

            throw new ApplicationException($"Found no matching numbers equal to {sum}");
        }
        
        public (int, int, int) FindThreeNumbersMatchingSum(int sum)
        {
            for (int leftTermIndex = 0; leftTermIndex < _expenses.Count-1; leftTermIndex++)
            {
                var leftTerm = _expenses[leftTermIndex];
                for (int middleTermIndex = 0; middleTermIndex < _expenses.Count-1; middleTermIndex++)
                {
                    var middleTerm = _expenses[middleTermIndex];
                    
                    if(leftTerm+middleTerm > sum)
                        continue;

                    for (int rightTermIndex = 0; rightTermIndex < _expenses.Count - 1; rightTermIndex++)
                    {
                        var rightTerm = _expenses[rightTermIndex];
                        if (leftTerm + middleTerm + rightTerm == sum)
                        {
                            return (leftTerm, middleTerm, rightTerm);
                        }
                        
                    }
                }
            }

            throw new ApplicationException($"Found no matching numbers equal to {sum}");
        }
    }
}
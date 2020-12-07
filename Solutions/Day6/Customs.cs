using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Day6
{
    public class Customs
    {
        private readonly List<GroupQuestionaire> groups = new List<GroupQuestionaire>();

        public Customs(List<string> groupInput)
        {
            var currentGroupQuestionaire = new StringBuilder();

            foreach (var line in groupInput)
            {
                currentGroupQuestionaire.AppendLine(line);
                
                if (line.Trim() == string.Empty)
                {
                    groups.Add(new GroupQuestionaire(currentGroupQuestionaire.ToString()));
                    currentGroupQuestionaire.Clear();
                }
            }
            
            groups.Add(new GroupQuestionaire(currentGroupQuestionaire.ToString()));
        }

        public int CountTotalUniqueAnswers()
        {
            return groups.Sum(x => x.UniqueAnswers);
        }
        
        public int CountAllSameAnswerPerGroup()
        {
            return groups.Sum(x => x.PeopleAnsweredSameAnswerCount);
        }
    }

    internal class GroupQuestionaire
    {
        public GroupQuestionaire(string answers)
        {
            AnswerPerPerson = answers.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Answers = answers.Replace(Environment.NewLine, "");
            UniqueAnswers = Answers.ToCharArray().Distinct().Count();

            var groupedByAnswer = Answers.GroupBy(c => c);
            
            var allPeopleAnswered = groupedByAnswer.Where(x => x.Count() == AnswerPerPerson.Length);
            PeopleAnsweredSameAnswerCount = allPeopleAnswered.Count();
        }

        public int PeopleAnsweredSameAnswerCount { get; set; }

        public string[] AnswerPerPerson { get; set; }

        public string Answers { get; set; }

        public int UniqueAnswers { get; set; }
    }
}
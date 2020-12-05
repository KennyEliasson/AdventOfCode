using System.Collections.Generic;
using System.Linq;
using System.Text;
using Solutions.Day4;

namespace Solutions
{
    public class PassportValidation<T> where T: Passport, new()
    {
        private readonly List<Passport> _passports;
        public PassportValidation(List<string> passportInput)
        {
            _passports = new List<Passport>();
            BuildPassports(passportInput);
        }

        private void BuildPassports(List<string> passportInput)
        {
            var currentPassport = new StringBuilder();

            foreach (var line in passportInput)
            {
                currentPassport.AppendLine(line);
                
                if (line.Trim() == string.Empty)
                {
                    _passports.Add(new T().Build(currentPassport.ToString()));
                    currentPassport.Clear();
                }
            }
            
            _passports.Add(new T().Build(currentPassport.ToString()));
        }

        public int Validate()
        {
            return _passports.Count(x => x.Valid());
        }
    }
}
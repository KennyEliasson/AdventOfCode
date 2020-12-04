using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

    public abstract class Passport
    {
        public abstract Passport Build(string passport);
        public abstract bool Valid();
    }

    public class PassportSimple : Passport
    {
        public override Passport Build(string passport)
        {
            passport = passport.Replace("\r\n", " ");

            var keyValues = passport.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyValue in keyValues)
            {
                var key = keyValue.Split(':')[0];
                var value = keyValue.Split(':')[1];
                switch (key.ToLowerInvariant())
                {
                    case "byr":
                        BirthYear = value;
                        break;
                    case "iyr":
                        IssueYear = value;
                        break;
                    case "eyr":
                        ExpirationYear = value;
                        break;
                    case "hgt":
                        Height = value;
                        break;
                    case "hcl":
                        HairColor = value;
                        break;
                    case "ecl":
                        EyeColor = value;
                        break;
                    case "pid":
                        PassportId = value;
                        break;
                    case "cid":
                        CountryId = value;
                        break;
                }
            }

            return this;
        }

        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public override bool Valid()
        {
            var hasBirthYear = !string.IsNullOrWhiteSpace(BirthYear);
            var hasIssueYear = !string.IsNullOrWhiteSpace(IssueYear);
            var hasExpirationYear = !string.IsNullOrWhiteSpace(ExpirationYear);
            var hasHeight = !string.IsNullOrWhiteSpace(Height);
            var hasHairColor = !string.IsNullOrWhiteSpace(HairColor);
            var hasEyeColor = !string.IsNullOrWhiteSpace(EyeColor);
            var hasPassportId = !string.IsNullOrWhiteSpace(PassportId);

            var valid = hasBirthYear && hasIssueYear && hasExpirationYear && hasHeight && hasHairColor && hasEyeColor && hasPassportId;
            return valid;
        }
    }

    public class PassportAdvanced : Passport
    {
        public int? TryParseNullable(string val)
        {
            int outValue;
            return int.TryParse(val, out outValue) ? (int?)outValue : null;
        }
        
        public override Passport Build(string passport)
        {
            passport = passport.Replace("\r\n", " ");

            var keyValues = passport.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var keyValue in keyValues)
            {
                var key = keyValue.Split(':')[0];
                var value = keyValue.Split(':')[1];
                switch (key.ToLowerInvariant())
                {
                    case "byr":
                        BirthYear = TryParseNullable(value);
                        break;
                    case "iyr":
                        IssueYear = TryParseNullable(value);
                        break;
                    case "eyr":
                        ExpirationYear = TryParseNullable(value);
                        break;
                    case "hgt":
                        Height = value;
                        break;
                    case "hcl":
                        HairColor = value;
                        break;
                    case "ecl":
                        EyeColor = value;
                        break;
                    case "pid":
                        PassportId = value;
                        break;
                    case "cid":
                        CountryId = value;
                        break;
                }
            }

            return this;
        }

        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }
        
        private Regex _hairColorRegex = new Regex("#[a-f0-9]{6}$", RegexOptions.Compiled);
        private Regex _passportIdRegex = new Regex("^[0-9]{9}$", RegexOptions.Compiled);
        private Regex _heightRegex = new Regex("^([0-9]+)(cm|in)", RegexOptions.Compiled);
        private List<string> _validEyeColors = new List<string>()
        {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };
        
        public override bool Valid()
        {
            var hasHeight = !string.IsNullOrWhiteSpace(Height);
            var hasHairColor = !string.IsNullOrWhiteSpace(HairColor);
            var hasEyeColor = !string.IsNullOrWhiteSpace(EyeColor);
            var hasPassportId = !string.IsNullOrWhiteSpace(PassportId);

            var valid = BirthYear.HasValue && IssueYear.HasValue && ExpirationYear.HasValue && hasHeight && hasHairColor && hasEyeColor && hasPassportId;

            if (!valid)
                return false;

            if (BirthYear < 1920 || BirthYear > 2002)
                return false;
            
            if (IssueYear < 2010 || IssueYear > 2020)
                return false;
            
            if (ExpirationYear < 2020 || ExpirationYear > 2030)
                return false;

            if (!_hairColorRegex.IsMatch(HairColor))
                return false;
            
            if (!_passportIdRegex.IsMatch(PassportId))
                return false;

            if (!_validEyeColors.Contains(EyeColor))
                return false;

            if (!_heightRegex.IsMatch(Height))
            {
                return false;
            }
            
            var match = _heightRegex.Match(Height);
            if (int.TryParse(match.Groups[1].Value, out var height))
            {
                if (match.Groups[2].Value == "cm")
                {
                    if (height < 150 || height > 193)
                    {
                        return false;
                    }
                } else if (match.Groups[2].Value == "in")
                {
                    if (height < 59 || height > 76)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
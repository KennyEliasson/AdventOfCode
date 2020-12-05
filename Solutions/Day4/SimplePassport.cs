using System;

namespace Solutions.Day4
{
    public class SimplePassport : Passport
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
}
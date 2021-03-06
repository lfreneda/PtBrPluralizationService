﻿using System.Text.RegularExpressions;

namespace PluralizationServices.Rules
{
    public class SpecialSingularizeRuleEndedInRZ : IPluralizationRule 
    {
        private const string Pattern = "(?<vogal>[rz])es$";

        public string Word { get; set; }

        public bool Verify() 
        {
            return Regex.IsMatch(Word, Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        public string Apply() 
        {
            return Regex.Replace(Word, Pattern, m => m.Groups["vogal"].Value);
        }
    }
}
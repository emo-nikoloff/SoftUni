/*Write a program, which matches a date in the format "dd{separator}MMM{separator}yyyy". Use named capturing groups in your regular expression.
Compose the Regular Expression
Every valid date has the following characteristics:
· Always starts with two digits, followed by a separator.
· After that, it has one uppercase and two lowercase letters (e.g. Jan, Mar).
· After that, it has a separator and exactly 4 digits (for the year).
· The separator could be either of three things: a period ('. '), a hyphen ('-') or a forward-slash ('/').
· The separator needs to be the same for the whole date (e.g. 13.03.2016 is valid, 13.03/2016 is NOT). Use a group backreference to check for this.*/
using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates;

class Program
{
    static void Main(string[] args)
    {
        string pattern = @"\b(?<date>\d{2})(?<separator>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>\d{4})\b";
        string dates = Console.ReadLine();

        Regex regex = new(pattern);

        MatchCollection matches = regex.Matches(dates);

        foreach (Match match in matches)
        {
            string date = match.Groups["date"].Value;
            string month = match.Groups["month"].Value;
            string year = match.Groups["year"].Value;

            Console.WriteLine($"Day: {date}, Month: {month}, Year: {year}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeworkTMS
{
    internal class TextAnalyzer
    {
        //Пока делал это задание, сильно полюбил LINQ
        private static readonly Dictionary<int, string> SingleDigits = new Dictionary<int, string>
        {
            { 0, "ноль" },
            { 1, "один" },
            { 2, "два" },
            { 3, "три" },
            { 4, "четыре" },
            { 5, "пять" },
            { 6, "шесть" },
            { 7, "семь" },
            { 8, "восемь" },
            { 9, "девять" }
        };

        public static string[] GetWords(string text)
        {
            return text.ToLower()
                .Split(new string[] { " ", ",", "!", "?", ".", ":", "\r\n", "\"", "—" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] GetSentences(string text)
        {
            text = text.Replace("\"", "");
            var pattern = @"(?<=[\.!\?])\s*";
            var rawSentences = Regex.Split(text, pattern);
            var result = rawSentences.Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            return result;
        }

        public static List<string> GetWordsWithMaxDigits(string text)
        {
            var words = GetWords(text);
            var wordInfos = words.Where(x => x.Any(char.IsLetter))
                .Select(x => new { Word = x, DigitsCount = x.Count(char.IsDigit) })
                .ToList();

            int maxDigits = wordInfos.Any() ? wordInfos.Max(x => x.DigitsCount) : 0;
            
            return wordInfos.Where(x => x.DigitsCount == maxDigits)
                .Select(x => x.Word)
                .ToList();
        }

        public static (List<string>, List<int>) GetLongestWordAndCount(string text)
        {
            var words = GetWords(text);
            var wordsAndCounts = new Dictionary<string, int>();
            var longestWords = new List<string>();
            var maxLength = 0;

            foreach (var word in words)
            {
                if (wordsAndCounts.ContainsKey(word))
                {
                    wordsAndCounts[word]++;
                }
                else
                {
                    wordsAndCounts.Add(word, 1);
                }

                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    longestWords.Clear();
                    longestWords.Add(word);
                }
                else if (word.Length == maxLength && !longestWords.Contains(word))
                {
                    longestWords.Add(word);
                }
            }

            var longestWordsOccurences = new List<int>();
            foreach (var word in longestWords)
            {
                longestWordsOccurences.Add(wordsAndCounts[word]);
            }

            return (longestWords, longestWordsOccurences);
        }

        public static string TurnDigitsToWords(string text)
        {
            var sb = new StringBuilder(text);

            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsDigit(sb[i]))
                {
                    var digitValue = (int)char.GetNumericValue(sb[i]);
                    string word = SingleDigits[digitValue];
                    sb.Remove(i, 1);
                    sb.Insert(i, word);
                    i += word.Length - 1;
                }
            }

            return sb.ToString();
        }

        public static string[] GetQuestionAndExclamatorySentences(string text)
        {
            var sentences = GetSentences(text);
            var result = new List<string>();

            var questionSentences = sentences.Where(x => x.EndsWith('?')).ToList();
            var exclamatorySentences = sentences.Where(x => x.EndsWith('!')).ToList();

            return questionSentences.Concat(exclamatorySentences).ToArray();
        }

        public static string[] GetSentencesWithoutCommas(string text)
        {
            var sentences = GetSentences(text);
            return sentences.Where(x => !x.Contains(',')).ToArray();
        }

        private static bool IsPalindrome(string str)
        {
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        public static string[] GetPalindromes(string text)
        {
            var words = GetWords(text);
            return words.Where(x => IsPalindrome(x))
                .ToArray();
        }

        public static string[] SeekForEntries(string text, string input)
        {
            var words = GetWords(text);

            return words.Where(x => x.ToLower().StartsWith(input))
                .ToArray();
        }

        public static string[] GetWordsWithStartMatchingEnd(string text)
        {
            var words = GetWords(text);
            return words.Where(x => x.EndsWith(x[0]))
                .ToArray();
        }
    }
}

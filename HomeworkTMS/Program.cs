using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTMS
{
    internal class Program
    {
        private const string TextExample = "Wow! This is my 1st test. Do you see number42? Yes! " +
            "\r\nOtto ran to room101. Anna loves level99. " +
            "\r\nAre you ready? No, I am not! " +
            "\r\nThis sentence has no comma. But this one, definitely has a comma, right? " +
            "\r\nHey! Look at Bob — he found 777 coins! " +
            "\r\nIs 12345 the longest digit-word? Maybe! " +
            "\r\nOtto said: \"Wow!\" Anna replied: \"Yes!\" " +
            "\r\nFinal test. Done!";

        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы Text Analyzer начата");
            Console.WriteLine();

            DemonstrateTask1_MaxDigits();
            DemonstrateTask2_LongestWord();
            DemonstrateTask3_ReplaceDigits();
            DemonstrateTask4_QuestionExclamatory();
            DemonstrateTask5_NoCommas();
            DemonstrateTask6_StartEndMatch();
            DemonstrateTask7_SearchByStart();
            DemonstrateTask8_Palindromes();

            Console.WriteLine("Все задачи завершены. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }


        private static void DemonstrateTask1_MaxDigits()
        {
            ShowTaskHeader("1. Найти слова, содержащие максимальное количество цифр");

            var result = TextAnalyzer.GetWordsWithMaxDigits(TextExample);
            PrintList(result, "Слова с максимальным количеством цифр:");

            WaitForNextTask();
        }

        private static void DemonstrateTask2_LongestWord()
        {
            ShowTaskHeader("2. Найти самое длинное слово и определить, сколько раз оно встретилось");

            var (words, counts) = TextAnalyzer.GetLongestWordAndCount(TextExample);

            Console.WriteLine("Самые длинные слова:");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($" - \"{words[i]}\" (встретилось {counts[i]} раз(а))");
            }

            WaitForNextTask();
        }

        private static void DemonstrateTask3_ReplaceDigits()
        {
            ShowTaskHeader("3. Заменить цифры 0-9 на слова (ноль, один...)");

            string result = TextAnalyzer.TurnDigitsToWords(TextExample);
            Console.WriteLine("Обработанный текст:");
            Console.WriteLine(result);

            WaitForNextTask();
        }

        private static void DemonstrateTask4_QuestionExclamatory()
        {
            ShowTaskHeader("4. Вывести сначала вопросительные, затем восклицательные предложения");

            var sentences = TextAnalyzer.GetQuestionAndExclamatorySentences(TextExample);
            PrintList(sentences, "Вопросительные и восклицательные предложения:");

            WaitForNextTask();
        }

        private static void DemonstrateTask5_NoCommas()
        {
            ShowTaskHeader("5. Вывести предложения, не содержащие запятых");

            var sentences = TextAnalyzer.GetSentencesWithoutCommas(TextExample);
            PrintList(sentences, "Предложения без запятых:");

            WaitForNextTask();
        }

        private static void DemonstrateTask6_StartEndMatch()
        {
            ShowTaskHeader("6. Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву");

            var matchingWords = TextAnalyzer.GetWordsWithStartMatchingEnd(TextExample);
            PrintList(matchingWords.Distinct().ToList(), "Слова с одинаковой первой и последней буквой:");

            WaitForNextTask();
        }

        private static void DemonstrateTask7_SearchByStart()
        {
            ShowTaskHeader("7. Поиск слов по части ввода (начало слова)");

            Console.Write("Введите начало слова для поиска (например, 'te' или 'nu'): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Ввод пуст. Поиск пропущен.");
            }
            else
            {
                var matches = TextAnalyzer.SeekForEntries(TextExample, input);

                if (matches.Any())
                    PrintList(matches, $"Слова, начинающиеся с '{input}':");
                else
                    Console.WriteLine($"Слова, начинающиеся с '{input}', не найдены.");
            }

            WaitForNextTask();
        }

        private static void DemonstrateTask8_Palindromes()
        {
            ShowTaskHeader("8. Найти палиндромы");

            var palindromes = TextAnalyzer.GetPalindromes(TextExample);
            PrintList(palindromes.Distinct().ToList(), "Найденные палиндромы:");

            WaitForNextTask(isLast: true);
        }

        private static void ShowTaskHeader(string title)
        {
            Console.Clear();
            Console.WriteLine($"=== {title} ===");

            Console.WriteLine();
            Console.WriteLine("[Исходный текст]:");
            Console.WriteLine(TextExample);
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
        }

        private static void WaitForNextTask(bool isLast = false)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            if (!isLast)
            {
                Console.WriteLine("Нажмите любую клавишу для перехода к следующей задаче...");
                Console.ReadKey();
            }
        }

        private static void PrintList(IEnumerable<string> items, string header)
        {
            Console.WriteLine(header);
            if (!items.Any())
            {
                Console.WriteLine(" (Не найдено)");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine($" -> {item}");
            }
        }
    }
}
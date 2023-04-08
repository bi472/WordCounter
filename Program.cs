using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: WordCounter <input_file>");
                return;
            }

            string inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Input file '{inputFile}' not found.");
                return;
            }

            string outputFile = "output.txt";

            Console.WriteLine("Counting words in {0}...", inputFile);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(inputFile, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', ',', '.', ':', ';', '(', ')', '[', ']', '-', '!', '?', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        string cleanWord = word.ToLowerInvariant();
                        if (!wordCounts.ContainsKey(cleanWord))
                        {
                            wordCounts[cleanWord] = 0;
                        }
                        wordCounts[cleanWord]++;
                    }
                }
            }

            Console.WriteLine("Sorting results...");

            List<KeyValuePair<string, int>> sortedWordCounts = wordCounts.ToList();
            sortedWordCounts.Sort((x, y) => y.Value.CompareTo(x.Value));

            Console.WriteLine("Writing results to {0}...", outputFile);

            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                foreach (KeyValuePair<string, int> pair in sortedWordCounts)
                {
                    writer.WriteLine("{0}\t{1}", pair.Key, pair.Value);
                }
            }

            Console.WriteLine("Done!");
        }
    }
}

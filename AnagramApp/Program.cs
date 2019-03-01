using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AnagramApp
{
    class Program
    {
        static ConcurrentDictionary<string, List<string>> dict = new ConcurrentDictionary<string, List<string>>();
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            //if (args.Length < 2)
            //{
            //    Console.WriteLine("Arguments invalid. Please provide a full path and an input string");
            //    return;
            //}

            var filepath = args[0];

            //if (!Directory.Exists(filepath))
            //{
            //    Console.WriteLine("Directory is invalid. Please provide a valid full path");
            //    return;
            //}

            var input = args[1];
            var result = string.Empty;
            
            var lines = new List<string>();
            using (var fs = File.Open(filepath, FileMode.Open))
            using (var bs = new BufferedStream(fs, 65536))
            using (var sr = new StreamReader(bs, Encoding.UTF8))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    if (!s.Length.Equals(input.Length)) continue;
                    lines.Add(s.ToLowerInvariant());
                }
            }

            Parallel.ForEach(lines, line =>
            {
                var chars = line.ToCharArray();
                Array.Sort(chars);
                
                var s = new string(chars);

                if (!dict.TryGetValue(s, out var words))
                {
                    dict.TryAdd(s, words = new List<string>());
                }

                words.Add(line);
            });

            var inputArray = input.ToLowerInvariant().ToCharArray();

            Array.Sort(inputArray);
            var key = new string(inputArray);

            if (dict.ContainsKey(key))
            {
                result = string.Join(',', dict[key]);
            }

            var stop = DateTime.Now - startTime;

            Console.WriteLine($"{stop.TotalMilliseconds}, {result}");
            Console.ReadLine();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var b = new FileHandler();
            string path = @"e:\Projects\Roman.txt";
            Dictionary<string, int> keywordCounts = new Dictionary<string, int>
        {
            { "что", 0 },
            { "Лев", 0 },
           
            // добавьте остальные ключевые слова в словарь
        };
            
            b.DoWork(path, keywordCounts);






            Console.ReadKey();
        }
    }
}

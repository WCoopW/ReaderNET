using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class FileHandler
    {
        /// <summary>
        /// Запуск работы 
        /// </summary>
        /// <param name="path">Путь к считываемому файлу</param>
        /// <param name="keywordCounts">Ключевые слова</param>
        /// <returns></returns>
        public  async Task DoWork(string path, Dictionary<string, int> keywordCounts) 
        {
            await Task.Run(() => Read(path, keywordCounts));
        }
        /// <summary>
        /// Считывание файла
        /// </summary>
        /// <param name="path">Путь к считываемому файлу</param>
        /// <param name="keywordCounts">Ключевые слова</param>
        /// <returns></returns>
        static async Task Read(string path, Dictionary<string,int> keywordCounts)
        {
            if (File.Exists(path)) // проверка на существование файла
            {
                using (var sr = new StreamReader(path))
                {
                    string? line;
                    while ((line = await sr.ReadLineAsync()) != null)  // считывание строки
                    {
                        String[] words = line.Split(new char[] { ' ', ',' });
                        foreach (string m in words) // поиск ключевых слов в строке
                        {
                            if (keywordCounts.ContainsKey(m))
                            {
                                keywordCounts[m]++;
                            }
                        }
                    }
                }
                foreach (KeyValuePair<string, int> pair in keywordCounts)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            }
            else
            {
                Console.WriteLine("Fine doesnt not exist.");
                return;
            }
        }
    }
}

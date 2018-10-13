using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;



namespace Lab_1
{
    class Program
    {

        static public void ReplaceInFile(string filePath)
        {
            string[] str = new string[3];
            string content;
            string searchText = ",";
            string replaceText = " Y: ";

            using (StreamReader reader = new StreamReader(filePath))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    content = reader.ReadLine();
                    str[i] = content;
                }
            }

            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Regex.Replace(str[i], searchText, replaceText);
                str[i] = str[i].Insert(0, "X: ");
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    writer.WriteLine(str[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            string filePath = @"file.txt";

            ReplaceInFile(filePath);

            using (StreamReader sr = new StreamReader(filePath))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}

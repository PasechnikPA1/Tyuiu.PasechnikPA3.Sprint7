using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.IlyinME.Sprint7.Project.V4.Lib
{
    public class DataService
    {
        public double AverageValue(double[] arrayNumber)
        {
            double avg = arrayNumber.Average();
            return avg;
        }
        public double MinValue(double[] arrayNumber)
        {
            double min = arrayNumber.Min();
            return min;
        }
        public double MaxValue(double[] arrayNumber)
        {
            double max = arrayNumber.Max();
            return max;
        }
        public string[,] LoadFromFileData(string path)
        {
            string filePath = File.ReadAllText(path, Encoding.GetEncoding(1251));

            filePath = filePath.Replace('\n', '\r');
            string[] lines = filePath.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length;
            int colums = lines[0].Split(';').Length;

            string[,] array = new string[rows, colums];

            for (int r = 0; r < rows; r++)
            {
                string[] liner = lines[r].Split(';');
                for (int c = 0; c < colums; c++)
                {
                    array[r, c] = liner[c];
                }
            }

            return array;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4_team1
{
    public static class MyFile
    {
        /// <summary>
        /// generates a file with required data
        /// </summary>
        /// <returns>true, if generating successful and false otherwise</returns>
        public static bool GenerateFile(string path)
        {
            if (!File.Exists(path))
            {
                // Create an array with data if necessary
                Random rand = new Random();
                int listSize = rand.Next(2, 5);
                List<double> dataList = new List<double>();

                // Create a file to write to
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < listSize; i++)
                    {
                        dataList.Add(rand.Next(0, 10000) * 0.01);
                        sw.Write(dataList[i] + " ");
                    }
                }

                return true;
            }

            return false;
        }
        /// <summary>
        /// swap 2 elemetns in a file
        /// </summary>
        /// <param name="path">path to a file</param>
        /// <returns></returns>
        public static bool SwapElements(string path)
        {
            if (File.Exists(path))
            {
                List<double> dataList = new List<double>();
                string s;

                // Open the file to read from
                using (StreamReader sr = File.OpenText(path))
                {
                    s = sr.ReadLine();
                }

                if (s != null)
                {
                    string[] strArr = s.Trim().Split(' ');

                    for (int i = 0; i < strArr.Length; i++)
                    {
                        try
                        {
                            dataList.Add(double.Parse(strArr[i]));
                        }
                        catch
                        {
                            return false;
                        }
                        
                    }

                    MyListExtentions.Swap(dataList, dataList.IndexOf(dataList.Max()), dataList.IndexOf(dataList.Min()));

                    // Open the file to write to
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            sw.Write(dataList[i] + " ");
                        }
                    }
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CopyFiles
{
    class Program
    {
        static public List<String> inFile = new List<String>();
        static public String outFile;

        static void Main(string[] args)
        {
            if (args[0].CompareTo("-i") == 0)
            {
                Boolean done = false;
                int x = 1;
                while (!done)
                {
                    if (args[x].CompareTo("-o") == 0)
                    {
                        outFile = new String(args[x+1].ToCharArray());
                        done = true;
                    }
                    else
                    {
                        String ss = new String(args[x].ToCharArray());
                        inFile.Add(ss);
                    }

                    x++;
                }
            }

            StreamWriter sw = new StreamWriter(outFile);

            foreach(String i in inFile)
            {
                StreamReader sr = new StreamReader(i);
                String s = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    sw.WriteLine(s.ToCharArray());
                    s = sr.ReadLine();
                }
                sw.WriteLine(s.ToCharArray());
                sr.Close();
            }

            sw.Close();
        }
    }
}

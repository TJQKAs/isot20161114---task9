using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Isot20161114wpf
{
   public static class Filter
    {
        public static void NoteFile(ObservableCollection<string> xarr, string file_name)
        {
            List<string> xann = xarr.ToList<string>();
            string path = file_name;
            StreamWriter fst = new StreamWriter(path);
            xann.ForEach(x => fst.WriteLine(x));
            fst.Close();
        }

        public static void ShowByteFile(string name_file)
        {
            FileStream fs = new FileStream(name_file, FileMode.OpenOrCreate);
            byte[] mas = new byte[fs.Length];
            fs.Read(mas, 0, mas.Length);
            string text = Encoding.UTF8.GetString(mas);
            foreach (byte b in mas)
            {
                Console.Write("-" + b + "-");
            }
            Console.WriteLine(text);
            fs.Close();
        }

        public static ObservableCollection<string> ReadFile(double score, string file_name)
        {
            ObservableCollection<string> gettext = new ObservableCollection<string>();
            using (StreamReader strd = new StreamReader(File.Open(file_name,FileMode.OpenOrCreate)))
            {

                string line;
                while ((line = strd.ReadLine()) != null)
                {
                    line = strd.ReadLine();
                    double currentScore = 0;
                    string[] lines = Regex.Split(line, " ");
                    double.TryParse(lines[9], out currentScore);
                    if (currentScore > score)
                    {
                        gettext.Add(line);
                    }
                }
                return gettext;
            }
        }

        public static ObservableCollection<string> WriteFilterCopyFile(double score, string file_name, string file_to_copy)
        {
            ObservableCollection<string> total = new ObservableCollection<string>();        
            total = ReadFile(score, file_name);
            List<string> listoftotal = total.ToList<string>();
            using (StreamWriter strw = new StreamWriter(File.Open(file_to_copy,FileMode.OpenOrCreate))) 
            {
                listoftotal.ForEach(x => strw.WriteLine(x));
                strw.Flush();
            }
            return total;
        }

        //public static int GetSomeStatData(ObservableCollection<string> x)
        //{
        //    int y = x.Count;
        //    return y;
        //}


    }
}

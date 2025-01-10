using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENV.Utilities
{
    public class Housekeeping
    {
        /*Yomeshlin Arumugam
          Created this class for General Housekeeping of Data/Files/Etc
          20190128*/

        public void HomeDrive()
        {
            UserMethods u = new UserMethods();

            System.IO.DirectoryInfo di = new DirectoryInfo(@u.IniGet("[MAGIC_LOGICAL_NAMES]pripath").Trim());

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.FullName.Contains("(") && file.FullName.Contains(")"))
                {
                    int start = file.FullName.IndexOf("(");
                    int end = file.FullName.IndexOf(")");
                    /*Console.WriteLine(start.ToString() + " " + end.ToString() + " " + file.FullName.Trim());
                    Console.WriteLine(file.FullName.Substring(start+1,end-start));*/
                    int countOfDashes = file.FullName.Substring(start - 1, end - start).Split('-').Length - 1;
                    // Console.WriteLine(countOfDashes+ file.FullName.Substring(start - 1, end - start));
                    if (file.LastWriteTime < (DateTime.Now - new TimeSpan(14, 0, 0, 0)) && countOfDashes == 4)
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch (System.IO.IOException)
                        {
                          
                        }
                       
                        //Console.WriteLine(file.FullName.Trim() +  ":" + file.CreationTime.ToShortDateString());
                    }
                }


            }

        }
    }
}


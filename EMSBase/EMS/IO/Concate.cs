using ENV;
using ENV.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EMSBase.Boxer.IO
{
    public class Concate
    {
        public static void Concat(string sourceFile,string destFile)
        {
            /*var cmd = new ProcessStartInfo("cmd.exe", String.Format("copy /b/y {1}+{0}={1}", sourceFile, destFile));
            var cmd = new ProcessStartInfo("cmd.exe", String.Format("/c copy {1}+{0}={1}", sourceFile, destFile));
            //cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.WindowStyle = ProcessWindowStyle.Normal;
            //cmd.WorkingDirectory = dirPath;
            cmd.UseShellExecute = false;
            Process.Start(cmd);*/
            UserMethods u = new UserMethods();
            string path = @u.IniGet("[MAGIC_LOGICAL_NAMES]pripath").Trim();
            if (!File.Exists(u.Trim(path) + u.Trim(destFile) + "(" + ProcessIdentifier.sessionId + ")"))
            {
               var myFile= File.Create(u.Trim(path)+u.Trim(destFile) + "(" + ProcessIdentifier.sessionId + ")");
                myFile.Close();
            }
            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.Arguments = String.Format("/c copy {1}+{0}={1}", u.Trim(path)+u.Trim(sourceFile) + "(" + ProcessIdentifier.sessionId + ")", u.Trim(path)+u.Trim(destFile) + "(" + ProcessIdentifier.sessionId + ")");
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.CreateNoWindow = true;
            compiler.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            compiler.Start();
            Console.WriteLine("Path:" + u.Trim(path) + u.Trim(sourceFile) + "(" + ProcessIdentifier.sessionId + ")" + "-" + u.Trim(path) + u.Trim(destFile) + "(" + ProcessIdentifier.sessionId + ")");
          Console.WriteLine(compiler.StandardOutput.ReadToEnd());

            compiler.WaitForExit();
        }

        // method name: ConcatMultipleFiles (replaces old cp.bat to concatenate multiple files into 1 output)
        // created: Jan 29, 2019 
        // Author: yomeshlina/dinob
        // Revisions: 







        public static void ConcatMultipleFiles(string[] sourceFiles, string destinationFile)
        {
            UserMethods u = new UserMethods();
            string path = @u.IniGet("[MAGIC_LOGICAL_NAMES]pripath").Trim();

            /*if(!File.Exists(path + destinationFile + "(" + ProcessIdentifier.sessionId + ")"))
            {
                using (File.Create(path + destinationFile + "(" + ProcessIdentifier.sessionId + ")"))
                {
                }
            }
                foreach (string srcFileName in sourceFiles)
                {

                using (Stream srcStream = File.OpenRead(path + srcFileName + "(" + ProcessIdentifier.sessionId + ")"))
                {
             
                    using (Stream destStreamTemp = File.OpenWrite(path + destinationFile + "(" + ProcessIdentifier.sessionId + "temp)"))
                    {
                        srcStream.CopyTo(destStreamTemp);
                    }
                }

                using (Stream destStream = File.OpenWrite(path + destinationFile + "(" + ProcessIdentifier.sessionId + ")"))
                        {
                            using (Stream destStreamTemp = File.OpenRead(path + destinationFile + "(" + ProcessIdentifier.sessionId + "temp)"))
                            {
                                destStreamTemp.CopyTo(destStream);
                            }
                    
                        }

                }
            
        }*/



        /*    using (StreamWriter destStream = File.AppendText(path + destinationFile + "(" + ProcessIdentifier.sessionId + ")"))
            {
                foreach (string srcFileName in sourceFiles)
                {
                    using (Stream srcStream = File.OpenRead(path + srcFileName + "(" + ProcessIdentifier.sessionId + ")"))
                    {

                        destStream.Write(srcStream);
                    }

                }
            }
        */
        }
        
    }
}

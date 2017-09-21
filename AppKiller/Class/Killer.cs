using System.Diagnostics;
using System.IO;
using System;

namespace AppKiller
{
    class Killer
    {
        public void kill()
        {            
            if (File.Exists(@"AppsToKill.txt"))
            {
                using (StreamReader sr = new StreamReader(@"AppsToKill.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        var line = sr.ReadLine();
                        if (line.Length > 0)
                        {
                            try
                            {
                                Process[] process = Process.GetProcessesByName(line);
                                foreach (var item in process)
                                {
                                    try
                                    {
                                        item.Kill();
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Process {0} could not be killed successfully.", item);
                                    }                                    
                                }
                            }
                            catch (System.Exception)
                            {
                                Console.WriteLine("Oops! Something went wrong while killing a process!");
                            }                            
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The file 'AppsToKill.txt' does not exist in application location. Nothing to kill!");
            }            
        }
    }
}

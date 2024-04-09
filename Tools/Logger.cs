using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

public class Logger
{
    public void TrAcE(int level, string block, int line, string log)
    {
        try
        {
            string FicheroAhora = (DateTime.Now.ToString("yyyyMMdd"));
            if (level > 0 && Data.LoggerLevel >= level && Data.LoggerLevel < 6)
            {
                try
                {
                    if (!Directory.Exists(Data.LoggerRoute))
                    {
                        Directory.CreateDirectory(Data.LoggerRoute);
                    }
                    string logFilePath = Path.Combine(Data.LoggerRoute, $"TrAcE_{FicheroAhora}.log");
                    string mensaje = $"Level:{level}>{DateTime.Now}>Block:{block}>Line:{line}>>>{log}\n";
                    File.AppendAllText(logFilePath, mensaje);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("TrAcE = Error: " + ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("TrAcE = Error: " + ex.Message);
        }
    }
}

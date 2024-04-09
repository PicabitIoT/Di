using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Data
{
    //app
    public static string AppName = "App: Db + Logger > TrAcE";
    public static string AppRoute = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\").Remove(0, 6);
    public static string AppVersion = "V 0.0.01 Rev 00";
    public static string AppYear = "2024 © " + DateTime.Now.Year.ToString();
    public static string LoggerRoute = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\").Remove(0, 6);
    public static int LoggerLevel = 5;
    //DBCon
    public static string Chain1 = Db.Properties.Settings.Default.dataBase1;
}


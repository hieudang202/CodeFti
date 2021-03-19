using AddOnLimitTransaction.Log;
using System;
using System.IO;
using System.Text;

namespace AddonPrintTransaction
{
    public class LogBusiness
    {
        public static void WriteLog(LogType logtype,string classNames, string str)
        {

            string strFolder = AppDomain.CurrentDomain.BaseDirectory + "LogAddon";
            string strPath = strFolder + @"\LogFile.txt";
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);

            var content = new StringBuilder();
            content.AppendLine(string.Format("{0} {1} {2}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), logtype.ToString(), classNames));
            content.AppendLine(str);
            File.AppendAllText(strPath, content.ToString());
        }
    }
}

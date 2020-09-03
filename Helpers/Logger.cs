using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Windows;

namespace Cinema.Helpers
{
    public class Logger
    {
       
        private static Logger instance;


        private static object syncRoot = new Object();

        protected Logger()
        {
                  

        }

        public  void WriteLog(string text)
        {
          string Path = string.Format($"/Logs/{0}_{1}_{2} .log", DateTime.Now.Date, DateTime.Now.Month, DateTime.Now.Year); ;

            try
            {
                if (!File.Exists(Path))
                    File.Create(Path);
                    File.AppendAllText(Path, DateTime.Now.ToString() + text);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Can't write log {0}", e.ToString());
            }
        }

        public static Logger getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Logger();
                }
            }
            return instance;
        }
    }
}
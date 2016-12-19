using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FridgeApp
{
    public class Logger
    {
        private static Logger _instance;
        private static string _path = @"../../Log.txt";
        // Only logs connection opened for some reason.
        private Logger()
        {
        }

        public void Log(string message)
        {
            StreamWriter file = new StreamWriter(_path, true);
            file.WriteLine(message);
            file.Close();
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }
                FileStream fs = File.Create(_path);
                fs.Close();
                _instance = new Logger();
            }
            return _instance;
        }
    }
}

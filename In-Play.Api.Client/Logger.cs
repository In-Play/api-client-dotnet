using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Play.Api.Client
{
    class Logger
    {
        private static NLog.ILogger Log { get; set; }

        static Logger()
        {
            Log = NLog.LogManager.GetCurrentClassLogger();
        }

        public static void Error(object msg)
        {
            Log.Error(msg);
        }

        public static void Error(string msg, Exception ex)
        {
            Log.Error(ex, msg);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Info(object msg)
        {
            Log.Info(msg);
        }
    }
}

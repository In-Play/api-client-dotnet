using System;
using NLog;

namespace In_Play.Api.Client
{
    internal class Logger
    {
        static Logger()
        {
            Log = LogManager.GetCurrentClassLogger();
        }

        private static ILogger Log { get; }

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
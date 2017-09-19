using log4net;
using System;
using System.Diagnostics;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace CloudManagement.Helper
{
    public class Logger
    {
        private static ILog Log => LogManager.GetLogger(new StackTrace().GetFrame(2).GetMethod().ReflectedType);

        public static void Fatal(object message)
        {
            if (Log.IsFatalEnabled)
            {
                Log.Fatal(message);
            }
        }

        public static void Fatal(object message, Exception exception)
        {
            if (Log.IsFatalEnabled)
            {
                Log.Fatal(message, exception);
            }
        }

        public static void Error(object message)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(message);
            }
        }

        public static void Error(object message, Exception exception)
        {
            if (Log.IsErrorEnabled)
            {
                Log.Error(message, exception);
            }
        }

        public static void Warn(object message)
        {
            if (Log.IsWarnEnabled)
            {
                Log.Warn(message);
            }
        }

        public static void Warn(object message, Exception exception)
        {
            if (Log.IsWarnEnabled)
            {
                Log.Warn(message, exception);
            }
        }

        public static void Info(object message)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(message);
            }
        }

        public static void Info(object message, Exception exception)
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(message, exception);
            }
        }

        public static void Debug(string message)
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug($"{new StackTrace().GetFrame(1).GetMethod()} : {message}");
            }
        }

        public static void Debug(object message, Exception exception)
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug($"{new StackTrace().GetFrame(1).GetMethod()} : {message}");
            }
        }
    }
}

using Logger.Appenders.Contracts;
using Logger.Appenders.Factory.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers;
using Logger.Loggers.Contracts;
using Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}

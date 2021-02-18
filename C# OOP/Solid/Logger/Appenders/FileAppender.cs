using Logger.Appenders.Contracts;
using Logger.Layouts.Contracts;
using Logger.Loggers.Contracts;
using Logger.Loggers.Enums;
using System;
using System.IO;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        private const string Path = "../../../log.txt";

        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = String.Format(this.layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

                File.AppendAllText(Path, content);
            }
        }
    }
}

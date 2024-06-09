using System;

enum LogLevel
{
    INFO,
    WARNING,
    ERROR
}

abstract class LoggerHandler
{
    protected LoggerHandler nextHandler;

    public LoggerHandler SetNext(LoggerHandler handler)
    {
        nextHandler = handler;
        return handler;
    }

    public virtual void LogMessage(LogLevel level, string message)
    {
        if (nextHandler != null)
        {
            nextHandler.LogMessage(level, message);
        }
    }
}

class InfoLoggerHandler : LoggerHandler
{
    public override void LogMessage(LogLevel level, string message)
    {
        if (level == LogLevel.INFO)
        {
            Console.WriteLine("INFO: " + message);
        }
        else
        {
            base.LogMessage(level, message);
        }
    }
}

class WarningLoggerHandler : LoggerHandler
{
    public override void LogMessage(LogLevel level, string message)
    {
        if (level == LogLevel.WARNING)
        {
            Console.WriteLine("WARNING: " + message);
        }
        else
        {
            base.LogMessage(level, message);
        }
    }
}

class ErrorLoggerHandler : LoggerHandler
{
    public override void LogMessage(LogLevel level, string message)
    {
        if (level == LogLevel.ERROR)
        {
            Console.WriteLine("ERROR: " + message);
        }
        else
        {
            base.LogMessage(level, message);
        }
    }
}

class Program
{
    static void Main()
    {
        var infoLogger = new InfoLoggerHandler();
        var warningLogger = new WarningLoggerHandler();
        var errorLogger = new ErrorLoggerHandler();

        infoLogger.SetNext(warningLogger).SetNext(errorLogger);

        infoLogger.LogMessage(LogLevel.INFO, "This is an info message.");
        infoLogger.LogMessage(LogLevel.WARNING, "This is a warning message.");
        infoLogger.LogMessage(LogLevel.ERROR, "This is an error message.");
    }
}

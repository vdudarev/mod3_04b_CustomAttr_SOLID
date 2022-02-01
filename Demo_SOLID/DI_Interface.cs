using System;
using System.Collections.Generic;
using System.IO;

namespace Demo_SOLID.DI
{
    public class Demo_DI {
        public static void Demo()
        {
            Console.WriteLine($"{Environment.NewLine}Сильная связность BadLogger и BadTool - плохое решение");
            BadTool bad = new BadTool();
            bad.DoSomeAction();

            Console.WriteLine("Слабая связность через интерфейс - хорошее решение");
            GoodTool goodConsole = new GoodTool(new ConsoleLogger());
            goodConsole.DoSomeAction();
            GoodTool goodFile = new GoodTool(new FileLogger());
            goodFile.DoSomeAction();
        }
    }

    #region Плохое решение
    /// <summary>
    /// журналирование
    /// </summary>
    class BadLogger {
        public void Log(string message) {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// композиция
    /// </summary>
    public class BadTool {
        BadLogger logger;
        public BadTool()
        {
            logger = new BadLogger();
        }

        public void DoSomeAction() {
            logger.Log("DoSomeAction");
        }
    }
    #endregion

    public interface ILogger {
        void Log(string msg);
    }

    #region Хорошее решение
    /// <summary>
    /// журналирование в консоль
    /// </summary>
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// журналирование в консоль
    /// </summary>
    class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", message);
        }
    }

    /// <summary>
    /// композиция
    /// </summary>
    public class GoodTool
    {
        ILogger logger;
        public GoodTool(ILogger logger)
        {
            this.logger = logger;
        }

        public void DoSomeAction()
        {
            logger.Log("DoSomeAction");
        }
    }
    #endregion
}

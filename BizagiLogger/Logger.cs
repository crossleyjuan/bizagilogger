using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizagiLogger
{
    public class Logger
    {
        private log4net.ILog _log;

        private static Dictionary<string, Logger> _loggers = new Dictionary<string, Logger>();
        private static object _lock = new object();

        static Logger()
        {
            XmlConfigurator.Configure();
        }

        public static Logger getLogger(string name)
        {
            if (!_loggers.ContainsKey(name))
            {
                lock (_lock)
                {
                    if (!_loggers.ContainsKey(name))
                    {
                        ILog log4 = LogManager.GetLogger(name);
                        Logger logger = new Logger(log4);
                        _loggers.Add(name, logger);
                    }
                }
            }
            return _loggers[name];
        }

        private Logger(log4net.ILog log)
        {
            this._log = log;
        }

        public void Debug(string caseId, string message)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push(caseId))
            {
                this._log.Debug(message);
            }
        }

        public void Warn(string caseId, string message)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push(caseId))
            {
                this._log.Warn(message);
            }
        }

        public void Info(string caseId, string message)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push(caseId))
            {
                this._log.Info(message);
            }
        }

        public void Error(string caseId, string message)
        {
            using (log4net.ThreadContext.Stacks["NDC"].Push(caseId))
            {
                this._log.Error(message);
            }
        }
    }
}

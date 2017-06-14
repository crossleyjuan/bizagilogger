using BizagiLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = Logger.getLogger("test");

            log.Debug("123", "test1");

            Logger log2 = Logger.getLogger("test");

            log.Debug("124", "test2");
            log.Debug("123", "test3");
            log.Debug("123", "test4");
            log.Debug("124", "test5");
            Console.Read();
        }
    }
}

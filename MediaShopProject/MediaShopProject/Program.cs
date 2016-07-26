using log4net;
using log4net.Core;
using MediaShopLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace MediaShopProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //ILog myLogger = LogManager.GetLogger("myLogger");
            //myLogger.Error("THERE WAS AN ERROR!!!");

            ModelMediaShopData model = new ModelMediaShopData();
            ItemController controller = new ItemController(model);
            //controller.AddBook(new Books());
            //controller.AddDvd(new DVD());

            //controller.RemoveBook();
        }
    }
}

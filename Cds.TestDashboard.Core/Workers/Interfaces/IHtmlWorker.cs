using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cds.TestDashboard.Core.Workers.Interfaces
{
    public interface IHtmlWorker
    {
        string GetElementByClassName(string content, string className, string elementType = "div");

        string GetElementById(string content, string id);
    }
}

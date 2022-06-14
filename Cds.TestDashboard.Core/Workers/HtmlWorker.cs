namespace Cds.TestDashboard.Core.Workers
{
    using Cds.TestDashboard.Core.Workers.Interfaces;
    using HtmlAgilityPack;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;

    public class HtmlWorker : WorkerBase, IHtmlWorker
    {
        public HtmlWorker(ILogger<WorkerBase> logger) : base(logger)
        {
        }

        public string GetElementByClassName(string content, string className, string elementType = "div")
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }

            var document = new HtmlDocument();
            document.LoadHtml(content);

            try
            {
                return document.DocumentNode.SelectNodes($"//{elementType}[@class='{className}']")
                      .Select(p => p.InnerHtml)
                      .FirstOrDefault();

            } catch (ArgumentNullException ex)
            {
                Logger.LogError(ex, ex.Message);
            }

            return null;
        }

        public string GetElementById(string content, string id)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var document = new HtmlDocument();
            document.LoadHtml(content);

            return document.GetElementbyId(id).InnerHtml;
        }
    }
}

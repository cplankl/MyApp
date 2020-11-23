using System.Linq;
using System.Threading.Tasks;
using MyApp.DataCrawlers.Base;
using MyApp.Interfaces;
using PuppeteerSharp;

namespace MyApp.DataCrawlers.Gpu
{
    public class HwLuxxDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(HwLuxxDataCrawler);

        private int? foundElements;

        protected override (bool, string) FoundExtendedContent(string content)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);

            var htmlNodes = doc.DocumentNode.Descendants()
                .Where(x => x.HasClass("message-cell--main"))
                .ToList();

            foundElements ??= htmlNodes.Count;

            if (foundElements != htmlNodes.Count)
            {
                var elementsToSkip = htmlNodes.Count - foundElements.Value;

                var newElements = htmlNodes.Skip(elementsToSkip).Select(x => x.InnerText);

                var message = string.Join(",", newElements);

                foundElements = htmlNodes.Count;

                return (true, message);
            }

            return (false, null);
        }

        protected override string Url { get; } =
            "https://www.hardwareluxx.de/community/threads/rtx-und-rx-gpu-verf%C3%BCgbarkeitshinweise.1281755/page-99999999";
    }
}
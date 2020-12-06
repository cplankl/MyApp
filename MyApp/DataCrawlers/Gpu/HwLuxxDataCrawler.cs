using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MyApp.DataCrawlers.Base;
using MyApp.Interfaces;
using PuppeteerSharp;

namespace MyApp.DataCrawlers.Gpu
{
    internal class TimeElementMapping
    {
        public HtmlNode Element { get; set; }
        public DateTime DateTime { get; set; }
    }

    public abstract class HwLuxxDataCrawler : DataCrawlerBase
    {
        private const string RegexPattern = "(?<=Name: )(.*)(?= Shop)";
        private const string PricePattern = "(?<=Preis: )(.*)(?= URL)";
        public override string CrawlerName { get; } = nameof(HwLuxxDataCrawler);

        private DateTime? lastTime;

        protected override (bool, string) FoundExtendedContent(string content)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);

            var htmlNodes = doc.DocumentNode.Descendants()
                .Where(x => x.HasClass("message-cell--main"))
                .ToList();

            var elementsWithDateTime = htmlNodes.Select(x => new TimeElementMapping
                {
                    DateTime = DateTime.Parse(x.Descendants("time").First()?.Attributes
                        .First(y => y.Name == "datetime")?.Value ?? DateTime.MinValue.ToString()),
                    Element = x
                })
                .Where(x => x.DateTime > DateTime.MinValue)
                .OrderByDescending(x => x.DateTime)
                .ToList();

            var latestTime = elementsWithDateTime.First();

            lastTime ??= latestTime.DateTime;

            if (latestTime.DateTime != lastTime)
            {
                var newElements = elementsWithDateTime.Where(x => x.DateTime > lastTime);

                var list = newElements.Select(x => x.Element.Descendants("div").Single(y => y.HasClass("bbWrapper")))
                    .Select(x =>
                        Regex.Match(x.InnerText.Replace("\n", " "), RegexPattern).Value +
                        " Preis: " +
                        Regex.Match(x.InnerText.Replace("\n", " "), PricePattern).Value +
                        " URL: " +
                        x.Descendants("a").First().GetAttributeValue("href", string.Empty))
                    .ToList();

                var message = string.Join("\n", list);

                lastTime = latestTime.DateTime;

                return (true, message);
            }

            return (false, null);
        }
    }

    internal sealed class HwLuxxNvidiaDataCrawler : HwLuxxDataCrawler
    {
        protected override string Url { get; } =
            "https://www.hardwareluxx.de/community/threads/rtx-und-rx-gpu-verf%C3%BCgbarkeitshinweise.1281755/page-99999999";
    }

    internal sealed class HwLuxxAmdDataCrawler : HwLuxxDataCrawler
    {
        protected override string Url { get; } =
            "https://www.hardwareluxx.de/community/threads/rx-gpu-verf%C3%BCgbarkeitshinweise.1282621/";
    }
}
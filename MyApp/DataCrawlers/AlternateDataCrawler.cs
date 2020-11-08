using System;
using System.Collections.Generic;
using System.Linq;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers
{
    internal class AlternateDataCrawler : DataCrawlerBase
    {
        protected override string Url { get; } = "https://www.alternate.de/html/product/1685590";

        private static readonly List<string> SuccessfulAvailabilities = new List<string>
        {
            "Auf Lager",
            "Ware im Zulauf",
        };

        protected override bool FoundContent(string content)
        {
            return SuccessfulAvailabilities.Any(x => content.Contains(x, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
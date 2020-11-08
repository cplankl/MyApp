using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers
{
    internal class MediaMarktDataCrawler : DataCrawlerBase
    {
        protected override bool FoundContent(string content)
        {
            var result = content.Contains("5900x", StringComparison.CurrentCultureIgnoreCase);

            return result;
        }

        protected override string Url { get; } = "https://www.mediamarkt.de/de/category/_amd-am4-cpu-692540.html";
    }
}
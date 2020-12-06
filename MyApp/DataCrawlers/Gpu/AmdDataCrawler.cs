using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal sealed class AmdDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = "AMD";

        protected override bool FoundContent(string content)
        {
            return content.Contains("6800", StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string Url => "https://www.amd.com/de/direct-buy/de";
    }

    internal sealed class AmdSecondGeneralDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(AmdSecondGeneralDataCrawler);
        protected override string Url { get; } = "https://www.amd.com/de/where-to-buy/radeon-rx-6000-series-graphics";


        protected override bool FoundContent(string content)
        {
            return !content.Contains("vorrättig") &&
                   !content.Contains("Wir müssen Ihnen leider mitteilen, dass AMD Radeon");
        }
    }
}
using System;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers.Gpu
{
    internal sealed class AmdExtendedDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(AmdExtendedDataCrawler);

        protected override bool FoundContent(string content)
        {
            return !content.Contains("Out of stock", StringComparison.CurrentCultureIgnoreCase) && ! content.Contains("Wir müssen Ihnen leider mitteilen, dass AMD Radeon");
        }

        protected override string Url { get; } = "https://www.amd.com/de/direct-buy/5458374100/de";
    }

    internal sealed class AmdExtendedTwoDataCrawler : DataCrawlerBase
    {
        public override string CrawlerName { get; } = nameof(AmdExtendedTwoDataCrawler);

        protected override bool FoundContent(string content)
        {
            return content.Contains("6800") && !content.Contains("Out of stock", StringComparison.CurrentCultureIgnoreCase) && !content.Contains("Wir müssen Ihnen leider mitteilen, dass AMD Radeon");
        }

        protected override string Url { get; } = "https://www.amd.com/de/direct-buy/545837400/de";
    }
}
using System.Collections.Generic;
using System.Linq;
using MyApp.DataCrawlers.Base;

namespace MyApp.DataCrawlers
{
    internal class NbbDataCrawler : DataCrawlerBase
    {
        protected override string Url { get; } =
            "https://www.notebooksbilliger.de/pc+hardware/prozessoren+pc+hardware/amd+prozessoren/amd+ryzen+5000/amd+ryzen+9+5900x+cpu+684032";

        private static readonly List<string> SuccessfulAvailabilities = new List<string>
        {
            "sofort ab Lager",
        };

        protected override bool FoundContent(string content)
        {
            return SuccessfulAvailabilities.Any(x => content.Contains(x));
        }
    }
}
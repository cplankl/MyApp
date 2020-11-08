using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    internal class AlternateDataCrawler : IDataCrawler
    {
        private const string AlternateUrl = "https://www.alternate.de/html/product/1685590";

        private static readonly List<string> SuccessfulAvailabilities = new List<string>
        {
            "Auf Lager",
            "Ware im Zulauf",
        };

        public async Task<(bool, string)> FindAsync(Browser browser)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync(AlternateUrl);

            // Store the HTML of the current page
            string content = await page.GetContentAsync();
            await page.CloseAsync();

            if (content.Length == 0)
            {
                throw new DataCrawlerException(nameof(NbbDataCrawler) + "cannot access page");
            }

            return (SuccessfulAvailabilities.Any(x => content.Contains(x, StringComparison.InvariantCultureIgnoreCase)),
                AlternateUrl);
        }
    }
}
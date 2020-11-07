using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    class AlternateDataCrawler : IDataCrawler
    {
        const string alternateUrl = "https://www.alternate.de/html/product/1685590";

        private static readonly List<string> SuccessfulAvailabilities = new List<string>
        {
            "Auf Lager",
            "Ware im Zulauf",
        };

        public async Task<(bool, string)> FindAsync()
        {
            // Download the Chromium revision if it does not already exist
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            await page.GoToAsync(alternateUrl);

            // Store the HTML of the current page
            string content = await page.GetContentAsync();
            await page.CloseAsync();

            if (content.Length == 0)
            {
                throw new DataCrawlerException(nameof(NbbDataCrawler) + "cannot access page");
            }

            return (SuccessfulAvailabilities.Any(x => content.Contains(x, StringComparison.InvariantCultureIgnoreCase)), alternateUrl);
        }
    }
}

using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    class NbbDataCrawler : IDataCrawler
    {
        const string nbbUrl = "https://www.notebooksbilliger.de/pc+hardware/prozessoren+pc+hardware/amd+prozessoren/amd+ryzen+5000/amd+ryzen+9+5900x+cpu+684032";

        private static readonly List<string> SuccessfulAvailabilities = new List<string>
        {
            "sofort ab Lager",
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
            await page.GoToAsync(nbbUrl);

            // Store the HTML of the current page
            string content = await page.GetContentAsync();
            await page.CloseAsync();

            if (content.Length == 0)
            {
                throw new DataCrawlerException(nameof(NbbDataCrawler) + "cannot access page");
            }

            return (SuccessfulAvailabilities.Any(x => content.Contains(x)), nbbUrl);
        }
    }
}

using PuppeteerSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    class MindfactoryDataCrawler : IDataCrawler
    {
        const string mindfactoryUrl = "https://www.mindfactory.de/product_info.php/AMD-Ryzen-9-5900X-12x-3-70GHz-So-AM4-WOF_1380728.html";

        const string missingPage = "<title>404 - Die Seite konnte nicht gefunden werden | Mindfactory.de</title>";

        public async Task<bool> FindAsync()
        {
            // Download the Chromium revision if it does not already exist
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            await page.GoToAsync(mindfactoryUrl);
            
            // Store the HTML of the current page
            string content = await page.GetContentAsync();

            return !content.Contains(missingPage);
        }
    }
}

using PuppeteerSharp;
using System.Threading.Tasks;

namespace MyApp
{
    partial class Program
    {
        class ProShopDataCrawler : IDataCrawler
        {
            private const string url = "https://www.proshop.de/CPU/AMD-Ryzen-9-5900X-CPU-12-Kerne-37-GHz-AMD-AM4-AMD-Boxed-WOF-kein-Kuehler/2884173";

            public async Task<(bool, string)> FindAsync()
            {
                // Download the Chromium revision if it does not already exist
                await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = false
                });

                var page = await browser.NewPageAsync();
                await page.GoToAsync(url);

                // Store the HTML of the current page
                string content = await page.GetContentAsync();

                await page.CloseAsync();

                return (!content.Contains("Die Ware ist leider nicht mehr verfügbar."), url);
            }
        }
    }
}

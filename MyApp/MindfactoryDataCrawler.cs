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

        public async Task<(bool, string)> FindAsync(Browser browser)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync(mindfactoryUrl);
            
            // Store the HTML of the current page
            string content = await page.GetContentAsync();
            await page.CloseAsync();

            return (!content.Contains(missingPage), mindfactoryUrl);
        }
    }
}

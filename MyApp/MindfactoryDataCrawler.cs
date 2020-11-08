using PuppeteerSharp;
using System.Threading.Tasks;

namespace MyApp
{
    internal class MindfactoryDataCrawler : IDataCrawler
    {
        private const string MindfactoryUrl = "https://www.mindfactory.de/product_info.php/AMD-Ryzen-9-5900X-12x-3-70GHz-So-AM4-WOF_1380728.html";
        private const string MissingPage = "<title>404 - Die Seite konnte nicht gefunden werden | Mindfactory.de</title>";

        public async Task<(bool, string)> FindAsync(Browser browser)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync(MindfactoryUrl);
            
            // Store the HTML of the current page
            var content = await page.GetContentAsync();
            await page.CloseAsync();

            return (!content.Contains(MissingPage), MindfactoryUrl);
        }
    }
}

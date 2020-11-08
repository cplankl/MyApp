using PuppeteerSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    internal class NbbDataCrawler : IDataCrawler
    {
        private const string NbbUrl =
            "https://www.notebooksbilliger.de/pc+hardware/prozessoren+pc+hardware/amd+prozessoren/amd+ryzen+5000/amd+ryzen+9+5900x+cpu+684032";

        private static readonly List<string> SuccessfulAvailabilities = new List<string>
        {
            "sofort ab Lager",
        };

        public async Task<(bool, string)> FindAsync(Browser browser)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync(NbbUrl);

            // Store the HTML of the current page
            var content = await page.GetContentAsync();
            await page.CloseAsync();

            if (content.Length == 0)
            {
                throw new DataCrawlerException(nameof(NbbDataCrawler) + "cannot access page");
            }

            return (SuccessfulAvailabilities.Any(x => content.Contains(x)), NbbUrl);
        }
    }
}
using System.Threading.Tasks;
using MyApp.Interfaces;
using PuppeteerSharp;

namespace MyApp.DataCrawlers.Base
{
    internal abstract class DataCrawlerBase: IDataCrawler
    {
        public virtual async Task<(bool Found, string Url)> FindAsync(Browser browser)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync(Url);

            // Store the HTML of the current page
            var content = await page.GetContentAsync();
            await page.CloseAsync();

            return (FoundContent(content), Url);
        }

        protected abstract bool FoundContent(string content);

        protected abstract string Url { get; }
    }
}
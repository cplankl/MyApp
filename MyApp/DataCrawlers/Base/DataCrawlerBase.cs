using System;
using System.Threading.Tasks;
using MyApp.Interfaces;
using PuppeteerSharp;

namespace MyApp.DataCrawlers.Base
{
    public abstract class DataCrawlerBase : IDataCrawler
    {
        public abstract string CrawlerName { get; }

        public virtual async Task<(bool Found, string Url)> FindAsync(Browser browser)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync(Url);

            // Store the HTML of the current page
            var content = await page.GetContentAsync();

            await page.CloseAsync();

            if (CheckForBotDetection(content))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Bot Detection gefunden bei {Url}");
                Console.ResetColor();

                return (false, string.Empty);
            }

            return (FoundContent(content), Url);
        }

        protected abstract bool FoundContent(string content);

        protected virtual bool CheckForBotDetection(string content) => false;

        protected abstract string Url { get; }
    }
}
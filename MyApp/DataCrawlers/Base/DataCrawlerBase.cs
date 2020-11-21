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
            await page.SetCacheEnabledAsync(false);
            await page.GoToAsync(Url);

            // Store the HTML of the current page
            var content = await page.GetContentAsync();
            
            if (CheckForBotDetection(content))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Bot Detection gefunden bei {Url}");
                Console.ResetColor();

                await page.CloseAsync();

                return (false, string.Empty);
            }

            var result = (FoundContent(content), Url);

            if (!result.Item1)
            {
                await page.CloseAsync();
            }

            return result;
        }

        protected abstract bool FoundContent(string content);

        protected virtual bool CheckForBotDetection(string content) => false;

        protected abstract string Url { get; }
    }
}
using System;
using System.Threading.Tasks;
using MyApp.Interfaces;
using PuppeteerSharp;

namespace MyApp.DataCrawlers.Base
{
    public abstract class DataCrawlerBase : IDataCrawler
    {
        public abstract string CrawlerName { get; }

        public virtual async Task<(bool Found, string Url, string Message)> FindAsync(Browser browser)
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

                return (false, string.Empty, null);
            }


            var extendedContent = FoundExtendedContent(content);
            var result = (extendedContent.Item1, Url, extendedContent.Item2);

            if (!result.Item1)
            {
                await page.CloseAsync();
            }

            return result;
        }

        protected virtual (bool, string) FoundExtendedContent(string content) => (FoundContent(content), null);

        protected virtual bool FoundContent(string content) => false;

        protected virtual bool CheckForBotDetection(string content) => false;

        protected abstract string Url { get; }
    }
}
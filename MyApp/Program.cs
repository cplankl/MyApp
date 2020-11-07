using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;

namespace MyApp
{
    partial class Program
    {

        static List<IDataCrawler> dataCrawlers = new List<IDataCrawler>()
        {
            new ProShopDataCrawler(),
            new AlternateDataCrawler(),
            new NbbDataCrawler(),
            new MindfactoryDataCrawler()

        };

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starte Suchvorgang...");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await CreateBrowser();

            while (true)
            {

                Console.WriteLine("Starte Suchlauf...");
                foreach (var crawler in dataCrawlers)
                {
                    if (browser.IsClosed)
                    {
                        browser = await CreateBrowser();
                    }

                    var (Found, Url) = await crawler.FindAsync(browser);

                    if (Found)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"CPU gefunden bei {Url}");
                        SystemSounds.Beep.Play();
                        Console.ResetColor();
                    }
                }

                await browser.CloseAsync();

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }

        private static async Task<Browser> CreateBrowser()
        {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });

            return browser;
        }
    }
}

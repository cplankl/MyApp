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

            // Download the Chromium revision if it does not already exist
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });

            while (true)
            {
                foreach (var crawler in dataCrawlers)
                {
                    if (browser.IsClosed)
                    {

                    }
                    var result = await crawler.FindAsync(browser);

                    if (result.Found)
                    {
                        Console.WriteLine($"CPU gefunden bei {result.Url}");
                        SystemSounds.Beep.Play();
                    }
                }

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
            }

            Console.ReadLine();
        }

        private async Task< Browser >CreateBrowser() {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });

            return browser;
        }
    }
}

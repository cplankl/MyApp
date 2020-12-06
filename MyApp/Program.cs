using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
using MyApp.DataCrawlers.Gpu;
using MyApp.Interfaces;

namespace MyApp
{
    internal class Program
    {
        private static readonly Random Random = new Random();

        private static readonly List<IDataCrawler> DataCrawlers = new List<IDataCrawler>()
        {
            new AmdDataCrawler(),
            new AmdExtendedDataCrawler(),
            new AmdExtendedTwoDataCrawler(),
            new AmdSecondGeneralDataCrawler(),
            //new AlternateDataCrawler()
            //new NbbDataCrawler()
            //new HwLuxxAmdDataCrawler(),
            //new HwLuxxNvidiaDataCrawler()
        };

        private static async Task Main()
        {
            Console.WriteLine("Starte Suchvorgang...");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await CreateBrowser();
            var counter = 1;

            while (true)
            {
                Console.WriteLine($"Starte Suchlauf {counter++} um {DateTime.Now.ToShortTimeString()}...");
                foreach (var crawler in DataCrawlers)
                {
                    if (browser.IsClosed)
                    {
                        browser = await CreateBrowser();
                    }

                    try
                    {
                        var (found, url, message) = await crawler.FindAsync(browser);

                        if (found)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(message ?? $"Gpu gefunden bei {url}");
                            SystemSounds.Beep.Play();
                            Console.ResetColor();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Fehler beim Pruefen von {crawler.CrawlerName}: {e.Message}");
                    }
                }
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(Random.Next(8,15)));
            }
        }

        private static async Task<Browser> CreateBrowser()
        {
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false,
            });

            return browser;
        }
    }
}
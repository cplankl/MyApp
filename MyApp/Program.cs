using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp
{

    class Program
    {
        class ProShopDataCrawler : IDataCrawler
        {
            private const string url = "https://www.proshop.de/CPU/AMD-Ryzen-9-5900X-CPU-12-Kerne-37-GHz-AMD-AM4-AMD-Boxed-WOF-kein-Kuehler/2884173";

            public async Task<bool> FindAsync()
            {
                // Download the Chromium revision if it does not already exist
                await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = false
                });

                var page = await browser.NewPageAsync();
                await page.GoToAsync(url);

                // Store the HTML of the current page
                string content = await page.GetContentAsync();

                await page.CloseAsync();

                return !content.Contains("Die Ware ist leider nicht mehr verfügbar.");
            }
        }

        static List<IDataCrawler> dataCrawlers = new List<IDataCrawler>()
        { 
            new ProShopDataCrawler(),
            new AlternateDataCrawler(),
            new NbbDataCrawler(),
            new MindfactoryDataCrawler()

        };

        static async Task Main(string[] args)
        {
            foreach(var crawler in dataCrawlers)
            {
                await  crawler.FindAsync();
            }

             var result = await new ProShopDataCrawler().FindAsync();
            SystemSounds.Beep.Play();

            Console.ReadLine();
        }
    }
}

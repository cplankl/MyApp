﻿using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Media;
using System.Threading.Tasks;
using MyApp.DataCrawlers;
using MyApp.Interfaces;

namespace MyApp
{
    internal class Program
    {
        private static readonly List<IDataCrawler> DataCrawlers = new List<IDataCrawler>()
        {
            new ProShopDataCrawler(),
            new AlternateDataCrawler(),
            new NbbDataCrawler(),
            new MindfactoryDataCrawler(),
            new MediaMarktDataCrawler(),
            new SaturnDataCrawler(),
            new AlzaDataCrawler(),
            new CsvDataCrawler()
        };

        private static async Task Main()
        {
            Console.WriteLine("Starte Suchvorgang...");

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await CreateBrowser();
            var counter = 1;

            while (true)
            {
                Console.WriteLine($"Starte Suchlauf {counter++}...");
                foreach (var crawler in DataCrawlers)
                {
                    if (browser.IsClosed)
                    {
                        browser = await CreateBrowser();
                    }

                    try
                    {
                        var (found, url) = await crawler.FindAsync(browser);

                        if (found)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine($"CPU gefunden bei {url}");
                            SystemSounds.Beep.Play();
                            Console.ResetColor();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Fehler beim Pruefen von {crawler.CrawlerName}: {e.Message}");
                    }
                }

                await browser.CloseAsync();

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(30));
            }

            // ReSharper disable once FunctionNeverReturns
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
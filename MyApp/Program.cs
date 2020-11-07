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

            while (true)
            {
                foreach (var crawler in dataCrawlers)
                {
                    var result = await crawler.FindAsync();

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
    }
}

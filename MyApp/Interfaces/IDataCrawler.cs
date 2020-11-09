using System.Threading.Tasks;
using PuppeteerSharp;

namespace MyApp.Interfaces
{
    internal interface IDataCrawler
    {
        string CrawlerName { get; }
        Task<(bool Found, string Url)> FindAsync(Browser browser);
    }
}

using System.Threading.Tasks;
using PuppeteerSharp;

namespace MyApp.Interfaces
{
    internal interface IDataCrawler
    {
        Task<(bool Found, string Url)> FindAsync(Browser browser);
    }
}

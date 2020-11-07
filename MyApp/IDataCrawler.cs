using System.Threading.Tasks;

namespace MyApp
{
    interface IDataCrawler
    {
        Task<(bool Found, string Url)> FindAsync();
    }
}

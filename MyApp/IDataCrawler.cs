using System.Threading.Tasks;

namespace MyApp
{
    interface IDataCrawler
    {
        Task<bool> FindAsync();
    }
}

using System;

namespace MyApp
{
    public class DataCrawlerException : Exception
    {
        public DataCrawlerException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}
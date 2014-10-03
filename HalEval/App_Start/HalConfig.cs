using System.Web.Http;
using WebApi.Hal;

namespace HalEval
{
    public static class HalConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Add(new JsonHalMediaTypeFormatter());
            config.Formatters.Add(new XmlHalMediaTypeFormatter());
        }
    }
}
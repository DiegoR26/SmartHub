using static System.Net.WebRequestMethods;

namespace SmartHub.Core
{
    public static class Configuration
    {
        public static string BackendUrl { get; set; } = "http://localhost:5085";
        public static string FrontendUrl { get; set;} = "http://localhost:5072";
    }
}

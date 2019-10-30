using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Taskworld.Core
{
    public class URLProvider
    {
        private static IDictionary<string, URLs> URLs { get; set; }

        public static string GetURL(string environment, string page)
        {
            var URLs = LoadURLs();
            if(!URLs.ContainsKey(environment))
            {

                throw new Exception($"Configuration missing : {environment}");
            }

            switch (page)
            {
                case PageURL.HomePage: return URLs[environment].HomePage;
                default: return string.Empty;
            }
        }

        private static IDictionary<string, URLs> LoadURLs()
        {
            if (URLs == null)
            {
                URLs = JsonConvert.DeserializeObject<IDictionary<string, URLs>>(File.ReadAllText(FilePath.URL));
            }

            return URLs;
        }
    }
}

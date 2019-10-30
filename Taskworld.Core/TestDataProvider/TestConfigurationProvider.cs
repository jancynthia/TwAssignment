using Newtonsoft.Json;
using System.IO;

namespace Taskworld.Core
{
    public class TestConfigurationProvider
    {
        public static TestConfiguration TestConfigurations { get; set; }

        public static string GetEnvironment()
        {
            var testConfiguration = LoadTestConfigurations();
            return testConfiguration.Environment;
        }

        private static TestConfiguration LoadTestConfigurations()
        {
            if (TestConfigurations == null)
            {
                TestConfigurations = JsonConvert.DeserializeObject<TestConfiguration>(File.ReadAllText(FilePath.TestConfiguration));
            }

            return TestConfigurations;
        }
    }
}

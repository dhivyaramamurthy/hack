// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallRequestResponseService
{
    public class ScoreData
    {
        public Dictionary<string, string> FeatureVector { get; set; }
        public Dictionary<string, string> GlobalParameters { get; set; }
    }

    public class ScoreRequest
    {
        public string Id { get; set; }
        public ScoreData Instance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InvokeRequestResponseService().Wait();
        }

        static async Task InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                ScoreData scoreData = new ScoreData()
                {
                    FeatureVector = new Dictionary<string, string>() 
                    {
                        { "Class", "0" },
                        { "age", "0" },
                        { "menopause", "0" },
                        { "tumor-size", "0" },
                        { "inv-nodes", "0" },
                        { "node-caps", "0" },
                        { "deg-malig", "0" },
                        { "breast", "0" },
                        { "breast-quad", "0" },
                        { "irradiat", "0" },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                ScoreRequest scoreRequest = new ScoreRequest()
                {
                    Id = "score00001",
                    Instance = scoreData
                };

                const string apiKey = "7pzmYJudte3MccE+DmzCI3/iujz5LGG139U5PoxCAZwwlcDj6tMhkIs+G0ZyNZZB1FlK+LAt92qmPFdjoFsfrA=="; // You can obtain the API key from the publisher of the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/72e26dad757b4b90b738139252c52779/services/bec91c3d2b61428581efe809259f7a82/score");
                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);
                }
                else
                {
                    Console.WriteLine("Failed with status code: {0}", response.StatusCode);
                }
                Console.ReadKey();
            }
        }
    }
}
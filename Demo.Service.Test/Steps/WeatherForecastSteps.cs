using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Demo.Service.Test.Setup;

namespace Demo.Service.Test.Steps
{
    [Binding]
    public class WeatherForecastSteps
    {
        private WebApplicationBuilder localServer;
        private HttpClient client;
        private HttpResponseMessage response;

        [Given("a local REST server is started")]
        public void StartLocalServer()
        {
            // Set up a local server
            localServer = new WebApplicationBuilder();
            localServer.StartServer();

            // Create an HTTP client
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
        }

        [When("I make a GET request to the API endpoint \"(.*)\"")]
        public async Task MakeGetRequest(string endpoint)
        {
            // Send a GET request to the specified endpoint
            response = await client.GetAsync(endpoint);
        }

        [Then("the response status code should be (\\d+)")]
        public void VerifyResponseStatusCode(int expectedStatusCode)
        {
            // Check if the response status code matches the expected status code
            Assert.Equal(expectedStatusCode, (int)response.StatusCode);
        }

        [Then("the response should contain expected data")]
        public async Task VerifyResponseData()
        {
            // Read the response content as a string
            var responseContent = await response.Content.ReadAsStringAsync();

            // Generate a JSON schema for the WeatherForecast class
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(WeatherForecast));

            // Set the schema type to "array"
            schema.Type = JSchemaType.Array;

            // Parse the response content as a JSON array
            JArray jsonArray = JArray.Parse(responseContent);

            // Validate the JSON array against the schema
            Assert.True(jsonArray.IsValid(schema));
        }
    }
}

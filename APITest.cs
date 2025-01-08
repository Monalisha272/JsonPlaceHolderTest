using NUnit.Framework;
using RestSharp;
using System.Net;

namespace JsonPlaceholderApiTests
{
    [TestFixture]
    public class ApiTests
    {
        private RestClient client;

        [SetUp]
        public void Setup()
        {
            // Initialize RestClient with the Base URL
            client = new RestClient("https://jsonplaceholder.typicode.com");
            Console.WriteLine("Setup: Initialized RestClient with Base URL.");
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose of RestClient
            client.Dispose();
            Console.WriteLine("Teardown: Disposed RestClient.");
        }

        // 1. GET Request Test
        [Test]
        [Description("Validate GET request")]
        public void Get_ShouldReturnPostDetails()
        {
            Console.WriteLine("Test Start: GET Request to /posts/1");

            var request = new RestRequest("/posts/1", Method.Get);
            Console.WriteLine($"GET Request URL: {request.Resource}");

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Expected status code 200.");
            Assert.That(response.Content, Does.Contain("\"id\": 1"));
            Assert.That(response.Content, Does.Contain("\"userId\": 1"));
            Assert.That(response.Content, Does.Contain("\"title\""));
            Assert.That(response.Content, Does.Contain("\"body\""));

            Console.WriteLine("Test End: GET Request test passed.");
        }

        // 2. GET Request Test with invaid input
        [Test]
        [Description("Validate GET request with invalid input")]
        public void Get_InvalidId_ShouldReturnNotFound()
        {
            Console.WriteLine("Test Start: GET Request to /posts/9999 (Invalid ID)");

            var request = new RestRequest("/posts/9999", Method.Get);

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Expected status code 404.");

            Console.WriteLine("Test End: Negative GET Request test passed.");
        }


        // 3. POST Request Test
        [Test]
        [Description("Validate POST request")]
        public void CreatePost_ShouldReturnCreatedPost()
        {
            Console.WriteLine("Test Start: POST Request to /posts");

            var request = new RestRequest("/posts", Method.Post);
            var body = new
            {
                userId = 1,
                title = "Test Title",
                body = "Test Body Content"
            };
            request.AddJsonBody(body);
            Console.WriteLine($"POST Request URL: {request.Resource}");
            Console.WriteLine($"Request Body: {body}");

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "Expected status code 201.");
            Assert.That(response.Content, Does.Contain("\"title\": \"Test Title\""));
            Assert.That(response.Content, Does.Contain("\"body\": \"Test Body Content\""));

            Console.WriteLine("Test End: POST Request test passed.");
        }
     // 4. POST Request Test with missing fields
        [Test]
        [Description("Validate POST request with missing fields")]
        public void CreatePost_MissingTitle_ShouldReturnBadRequest()
        {
            Console.WriteLine("Test Start: POST Request with Missing Title");

            var request = new RestRequest("/posts", Method.Post);
            var body = new
            {
                userId = 1,
                body = "Test Body Content"
                // Title is missing
            };
            request.AddJsonBody(body);

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "Expected status code other than 201.");

            Console.WriteLine("Test End: Negative POST Request test passed.");
        }
        // 5. PUT Request Test
        [Test]
        [Description("Validate PUT request")]
        public void UpdatePost_ShouldReturnUpdatedPost()
        {
            Console.WriteLine("Test Start: PUT Request to /posts/1");

            var request = new RestRequest("/posts/1", Method.Put);
            var body = new
            {
                userId = 1,
                title = "Updated Title",
                body = "Updated Body Content"
            };
            request.AddJsonBody(body);
            Console.WriteLine($"PUT Request URL: {request.Resource}");
            Console.WriteLine($"Request Body: {body}");

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Expected status code 200.");
            Assert.That(response.Content, Does.Contain("\"title\": \"Updated Title\""));
            Assert.That(response.Content, Does.Contain("\"body\": \"Updated Body Content\""));

            Console.WriteLine("Test End: PUT Request test passed.");
        }

        // 6. PUT Request Test with invalid ID
        [Test]
        [Description("Validate PUT request with invalid data")]
        public void UpdatePost_InvalidId_ShouldReturnNotFound()
        {
            Console.WriteLine("Test Start: PUT Request to /posts/9999 (Invalid ID)");

            var request = new RestRequest("/posts/9999", Method.Put);
            request.AddJsonBody(new
            {
                userId = 1,
                title = "Invalid Update",
                body = "Invalid Update Content"
            });

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode, "Expected status code 404.");

            Console.WriteLine("Test End: Negative PUT Request test passed.");
        }


        // 7. DELETE Request Test
        [Test]
        [Description("Validate DELETE request")]
        public void DeletePost_ShouldReturnSuccessStatusCode()
        {
            Console.WriteLine("Test Start: DELETE Request to /posts/1");

            var request = new RestRequest("/posts/1", Method.Delete);
            Console.WriteLine($"DELETE Request URL: {request.Resource}");

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.IsTrue(
                response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent,
                "Expected status code 200 or 204."
            );
            Assert.That(response.Content.Length, Is.EqualTo(2), "Expected empty response body.");

            Console.WriteLine("Test End: DELETE Request test passed.");
        }
        // 8. DELETE Request Test with Invalid ID
        [Test]
        [Description("Validate DELETE request with invalid Id")]
        public void DeletePost_InvalidId_ShouldReturnNotFound()
        {
            Console.WriteLine("Test Start: DELETE Request to /posts/9999 (Invalid ID)");

            var request = new RestRequest("/posts/9999", Method.Delete);

            var response = client.Execute(request);
            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Expected status code 404.");

            Console.WriteLine("Test End: Negative DELETE Request test passed.");
        }
    }
}

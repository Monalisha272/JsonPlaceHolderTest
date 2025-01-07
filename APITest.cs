using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APITests
{
    [TestFixture]
    public class JsonPlaceholderTests
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/")
            };
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task GetPostById_ShouldReturnExpectedPost()
        {
            // Arrange
            var postId = 1;

            // Act
            var response = await _client.GetAsync($"/posts/{postId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var post = JsonSerializer.Deserialize<Post>(responseBody);
            Assert.AreEqual(1, post.UserId);
            Assert.AreEqual(1, post.Id);
            Assert.IsNotNull(post.Title);
            Assert.IsNotNull(post.Body);
        }

        [Test]
        public async Task CreateNewPost_ShouldReturnCreatedPost()
        {
            // Arrange
            var newPost = new Post
            {
                UserId = 1,
                Title = "New Post Title",
                Body = "This is the body of the new post."
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(newPost), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/posts", jsonContent);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var createdPost = JsonSerializer.Deserialize<Post>(responseBody);
            Assert.AreEqual(newPost.UserId, createdPost.UserId);
            Assert.AreEqual(newPost.Title, createdPost.Title);
            Assert.AreEqual(newPost.Body, createdPost.Body);
        }

        [Test]
        public async Task UpdatePostById_ShouldReturnUpdatedPost()
        {
            // Arrange
            var updatedPost = new Post
            {
                UserId = 1,
                Title = "Updated Title",
                Body = "Updated body content."
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(updatedPost), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/posts/1", jsonContent);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var returnedPost = JsonSerializer.Deserialize<Post>(responseBody);
            Assert.AreEqual(updatedPost.UserId, returnedPost.UserId);
            Assert.AreEqual(updatedPost.Title, returnedPost.Title);
            Assert.AreEqual(updatedPost.Body, returnedPost.Body);
        }

        [Test]
        public async Task DeletePostById_ShouldReturnNoContent()
        {
            // Arrange
            var postId = 1;

            // Act
            var response = await _client.DeleteAsync($"/posts/{postId}");

            // Assert
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent);

            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(string.IsNullOrEmpty(responseBody));
        }

        public class Post
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}

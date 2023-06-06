using Unsplasharp;
using UnsplashsharpTest.Data;

namespace Unsplash.Net.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task SearchPhotosTest()
        {
            var query = "mountains";
            var client = new UnsplasharpClient(Credentials.AccessKey);
            var photosFound = await client.SearchPhotos(query);
            var photosFoundPaged = await client.SearchPhotos(query, 2);

            Assert.IsTrue(photosFound.Count > 0);
            Assert.IsTrue(photosFoundPaged.Count > 0);

            Assert.IsNotNull(client.LastPhotosSearchQuery);
            Assert.IsTrue(client.LastPhotosSearchTotalPages > 0);
            Assert.IsTrue(client.LastPhotosSearchTotalResults > 0);
        }
    }
}
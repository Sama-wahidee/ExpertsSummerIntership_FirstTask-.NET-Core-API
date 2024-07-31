using System.Collections.Generic;
using System.Threading.Tasks;
using FirstTask_.NET_Core_API.Data.Models;
using RestSharp;
//Sama wahidee
namespace FirstTask_.NET_Core_API.Data.Services
{
    public class PostsService
    {
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com";

        public async Task<Post> CreatePost(Post post)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("posts", Method.Post);
            request.AddJsonBody(post);
            var response = await client.ExecuteAsync<Post>(request);
            return response.Data;
        }

        public async Task<Post> UpdatePost(int id, Post post)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"posts/{id}", Method.Put);
            request.AddJsonBody(post);
            var response = await client.ExecuteAsync<Post>(request);
            return response.Data;
        }

        public async Task<Post> GetPostById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"posts/{id}", Method.Get);
            var response = await client.ExecuteAsync<Post>(request);
            return response.Data;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("posts", Method.Get);
            var response = await client.ExecuteAsync<List<Post>>(request);
            return response.Data;
        }

        public async Task<bool> DeletePost(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"posts/{id}", Method.Delete);
            var response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}

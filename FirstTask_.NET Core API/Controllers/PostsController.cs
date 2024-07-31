using FirstTask_.NET_Core_API.Data.Models;
using FirstTask_.NET_Core_API.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstTask_.NET_Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostsService _postsService;

        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            var createdPost = await _postsService.CreatePost(post);
            return Ok(createdPost);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            var updatedPost = await _postsService.UpdatePost(id, post);
            return Ok(updatedPost);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postsService.GetPostById(id);
            return Ok(post);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var allPosts = await _postsService.GetAllPosts();
            return Ok(allPosts);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var isDeleted = await _postsService.DeletePost(id);
            return Ok(isDeleted);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyInstagramApi.Interfaces;
using MyInstagramApi.Models;
using System;
using System.Threading.Tasks;

namespace MyInstagramApi.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikeController
    {
        private readonly IPostRepository _postRepository;

        public LikeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost("{guid}")]
        public async Task<Post> Like([FromRoute]Guid guid)
        {
            var post = await _postRepository.GetByIdAsync(guid);

            post.Likes ++;

            await _postRepository.UpdateAsync(post);

            return post;
        }
    }
}

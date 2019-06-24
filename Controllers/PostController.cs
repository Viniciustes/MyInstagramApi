using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyInstagramApi.Interfaces;
using MyInstagramApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MyInstagramApi.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IList<Post>> GetAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        public async Task<Post> PostAsync([FromForm] Post post, IFormFile image)
        {
            if (image.Length > 0)
            {
                var folderName = Path.Combine("Uploads", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fileName = image.FileName;
                var fullPath = Path.Combine(pathToSave, fileName);

                using var stream = new FileStream(fullPath, FileMode.Create);

                image.CopyTo(stream);

                post.Image = fileName;
            }

            return await _postRepository.CreateAsync(post);
        }
    }
}

using MyInstagramApi.Contexts;
using MyInstagramApi.Interfaces;
using MyInstagramApi.Models;

namespace MyInstagramApi.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private static readonly string nameColection = "post";

        public PostRepository(MyInstagramContextDb context) : base(context, nameColection)
        {
        }
    }
}

namespace MyInstagramApi.Models
{
    public class Post : BaseModel
    {
        public string Author { get; set; }

        public string Place { get; set; }

        public string HashTags { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int Likes { get; set; }
    }
}

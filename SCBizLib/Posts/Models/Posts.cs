using System;

namespace SCBizLib.Posts
{
    public class Posts { }

    public class BasePost
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int GroupId { get; set; }
        public int ParentId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public PostStatus PostStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum PostStatus
    {
        None = 0,
        Drafted = 2,
        Published = 5,
        Invisibled = 8,
        Disabled = 9
    }
}

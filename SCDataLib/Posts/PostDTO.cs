using Dapper;
using SCBizLib.Posts;
using System;
using System.Configuration;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Data;
using CommonLib;

namespace SCDataLib
{
    public class PostDTO
    {
        [System.Data.Linq.Mapping.Column(Name = "ID")]
        public int Id { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "POST_ID")]
        public int PostId { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "GROUP_ID")]
        public int GroupId { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "PARENT_ID")]
        public int ParentId { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "POST_TITLE")]
        public string PostTitle { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "POST_CONTENT")]
        public string PostContent { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "POST_STATUS")]
        public PostStatus PostStatus { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "CREATED_AT")]
        public DateTime CreatedAt { get; set; }
    }
}

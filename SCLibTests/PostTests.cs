using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCBizLib;
using SCBizLib.Posts;
using System;
using System.Collections.Generic;

namespace SCLibTests
{
    [TestClass]
    public class PostTests
    {
        /// <summary>
        /// 글번호와 글그룹번호로 조회할 수 있는가?
        /// - 글그룹번호에 속한 글번호를 채번함.
        /// </summary>
        [TestMethod]
        public void Inquiry_A_Post_By_PostId_GroupId_Returns_PostInfo()
        {
            PostService service = new PostService();
            BasePost post = service.GetPostInfo(1, 10000, null);
            Assert.IsNotNull(post);
            Assert.AreNotEqual(string.IsNullOrEmpty(post.PostTitle), true);
        }
    }
}

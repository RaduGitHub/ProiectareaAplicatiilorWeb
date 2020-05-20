using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.ApplicationLogic.Model
{
    public class Comment
    {
        public Guid CommentID { get; set; }
        public string Text { get; set; }
        public double Score{ get; set; }
        public Guid CreatorID { get; set; }
        public Guid GameId { get; set; }
    }
}

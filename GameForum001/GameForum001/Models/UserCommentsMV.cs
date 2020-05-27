using GameForum.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameForum001.Models
{
    public class UserCommentsMV
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public Guid GameID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NOComments { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Guid CreatorID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Image { get; set; }
        public Guid CommentID { get; set; }
        public string Text { get; set; }
        public double Score { get; set; }
        public Guid GameId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.ApplicationLogic.Model
{
    public class Game
    {
        public Guid GameID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
        public int NOComments { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Guid CreatorID { get; set; }
        public int DateCreated { get; set; }
    }
}

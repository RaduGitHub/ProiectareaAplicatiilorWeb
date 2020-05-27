using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameForum001.Models
{
    public class AddGameMV
    {
        public Guid GameID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
        public int NOComments { get; set; }
        public Guid CreatorID { get; set; }
        public DateTime DateCreated { get; set; }
        public IFormFile Image { get; set; }
    }
}

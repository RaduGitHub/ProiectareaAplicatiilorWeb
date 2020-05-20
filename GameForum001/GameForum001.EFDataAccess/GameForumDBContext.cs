using GameForum.ApplicationLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum001.EFDataAccess
{
    public class GameForumDBContext: DbContext
    {
        public GameForumDBContext(DbContextOptions<GameForumDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}

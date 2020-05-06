using GameForum.ApplicationLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.EFDataAccess
{
    public class GameForumDbContext : DbContext
    {
        public GameForumDbContext(DbContextOptions<GameForumDbContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}

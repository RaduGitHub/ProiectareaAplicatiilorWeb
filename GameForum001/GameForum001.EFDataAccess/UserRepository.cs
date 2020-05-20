using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using GameForum.ApplicationLogic;
using GameForum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameForum001.EFDataAccess;

namespace GameForum.EFDataAccess
{
    public class UserRepository: BaseRepository<User>, IUser
    {
        public UserRepository(GameForumDBContext dbContext):base(dbContext)
        {

        }
        public User GetUserByUserId(Guid userId)
        {
            return dbContext.Users.Where(User => User.ID == userId).SingleOrDefault();
        }

        public string GetRank(Guid userId)
        {
            bool admin = dbContext.Users.Where(User => User.ID == userId).Select(User => User.IsAdmin).SingleOrDefault();
            if (admin == true)
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }

        public double GetScore(Guid userId)
        {
            return dbContext.Users.Where(User => User.ID == userId).Select(User => User.Score).SingleOrDefault();
        }
    }
}

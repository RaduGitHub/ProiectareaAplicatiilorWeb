using GameForum.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.ApplicationLogic.Abstractions
{
    public interface IUser : IRepository<User>
    {
        double GetScore(Guid UserId);
        string GetRank(Guid UserId);
        User GetUserByUserId(Guid userId);
    }
}

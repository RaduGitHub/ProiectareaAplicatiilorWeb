using System;
using System.Collections.Generic;
using System.Text;
using GameForum.ApplicationLogic.Model;

namespace GameForum.ApplicationLogic.Abstractions
{
    public interface IComment : IRepository<Comment>
    {
        double GetScore(Guid CommentId);
        Comment GetCommentByCommentId(Guid CommentId);

        Comment GetCommentByGameId(Guid GameId);
    }
}

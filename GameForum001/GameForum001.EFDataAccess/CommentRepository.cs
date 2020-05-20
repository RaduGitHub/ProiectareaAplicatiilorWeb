using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using GameForum.DataAccess;
using GameForum001.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameForum.EFDataAccess
{
    public class CommentRepository : BaseRepository<Comment>, IComment
    {
        public CommentRepository(GameForumDBContext dbContext) : base(dbContext)
        {

        }
        public Comment GetCommentByCommentId(Guid CommentId)
        {
            return dbContext.Comment
                .Where(Comment => Comment.GameId == CommentId)
                .SingleOrDefault();
        }

        public Comment GetCommentByGameId(Guid GameId)
        {
            return dbContext.Comment
                .Where(Comment => Comment.GameId == GameId)
                .SingleOrDefault();
        }

        public double GetScore(Guid CommentId)
        {
            return dbContext.Comment.Where(Comment => Comment.CommentID == CommentId).Select(Comment => Comment.Score).SingleOrDefault();
        }
    }
}
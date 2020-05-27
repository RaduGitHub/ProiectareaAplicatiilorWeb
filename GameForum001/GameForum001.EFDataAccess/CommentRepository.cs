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
                .Where(Comment => Comment.CommentID == CommentId)
                .SingleOrDefault();
        }
        public Comment GetCommentByUserId(Guid UserId)
        {
            return dbContext.Comment
                .Where(Comment => Comment.CreatorID == UserId)
                .SingleOrDefault();
        }

        public IEnumerable<Comment> GetCommentForGameId(Guid GameId)
        {
            return dbContext.Comment
                .Where(Comment => Comment.GameId == GameId)
                .AsEnumerable();
        }

        public double GetScore(Guid CommentId)
        {
            return dbContext.Comment.Where(Comment => Comment.CommentID == CommentId).Select(Comment => Comment.Score).SingleOrDefault();
        }

        public IEnumerable<Comment> GetCommentForUserId(Guid UserId)
        {
            return dbContext.Comment
                .Where(c => c.CreatorID == UserId)
                .AsEnumerable();
        }
    }
}
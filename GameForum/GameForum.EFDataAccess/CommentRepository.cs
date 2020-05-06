using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using GameForum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameForum.EFDataAccess
{
    public class CommentRepository : BaseRepository<Comment>, IComment
    {
        public CommentRepository(GameForumDbContext dbContext) : base(dbContext)
        {

        }
        public Comment GetCommentByCommentId(Guid CommentId)
        {
            return dbContext.Comment
                .Where(Comment => Comment.CommentID == CommentId)
                .SingleOrDefault();
        }

        public double GetScore(Guid CommentId)
        {
            return dbContext.Comment.Where(Comment => Comment.CommentID == CommentId).Select(Comment => Comment.Score).SingleOrDefault();
        }
    }
}
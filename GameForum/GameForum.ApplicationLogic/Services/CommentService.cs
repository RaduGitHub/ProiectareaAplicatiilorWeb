using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Exceptions;
using GameForum.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameForum.ApplicationLogic.Services
{
    public class CommentService
    {
        private IUser userRepository;
        private Abstractions.GameService gameRepository;
        private IComment commentRepository;

        public CommentService(IUser userRepository, Abstractions.GameService gameRepository, IComment commentRepository)
        {
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
            this.commentRepository = commentRepository;
        }
        public double GetScore(string commentId)
        {
            
            Guid commentIdGuid = Guid.Empty;
            if (!Guid.TryParse(commentId, out commentIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var comment = commentRepository.GetCommentByCommentId(commentIdGuid);
            if (comment == null)
            {
                throw new EntityNotFoundException(commentIdGuid);
            }

            return comment.Score;
        }
        public Comment GetCommentByCommentId(string commentId)
        {

            Guid commentIdGuid = Guid.Empty;
            if (!Guid.TryParse(commentId, out commentIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var comment = commentRepository.GetCommentByCommentId(commentIdGuid);
            if (comment == null)
            {
                throw new EntityNotFoundException(commentIdGuid);
            }

            return comment;
        }

        public User GetUserForComment(string commentId)
        {

            Guid commentIdGuid = Guid.Empty;
            if (!Guid.TryParse(commentId, out commentIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var comment = commentRepository.GetCommentByCommentId(commentIdGuid);
            if (comment == null)
            {
                throw new EntityNotFoundException(commentIdGuid);
            }

            return userRepository.GetUserByUserId(commentIdGuid);
        
        }

        public void EditComment(string commentId, string Text) 
        {
            Guid commentIdGuid = Guid.Empty;
            if (!Guid.TryParse(commentId, out commentIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            if (Text == null)
            {
                throw new EmptyCommentException(commentIdGuid);
            }
            var comment = commentRepository.GetCommentByCommentId(commentIdGuid);
            comment.Text = Text;
            commentRepository.Update(comment);
        }
    }
}

using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Exceptions;
using GameForum.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameForum.ApplicationLogic.Model;

namespace GameForum.ApplicationLogic.Services
{
    public class UserService
    {
        private IUser userRepository;
        private Abstractions.GameService gameRepository;
        private IComment commentRepository;

        public UserService(IUser userRepository, Abstractions.GameService gameRepository, IComment commentRepository)
        {
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
            this.commentRepository = commentRepository;
        }
        public void CreateNewUser(Guid id, string email, string password, bool isAdmin)
        {
            var user = new Model.User() { Email = email, Username = email, Password = password, IsAdmin = isAdmin };
            user = userRepository.Add(user);
        }
        public User GetUserByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if(!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var user = userRepository.GetUserByUserId(userIdGuid);
            if(user == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return user;
        }

        public IEnumerable<Comment> GetUserComments(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if(!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return commentRepository.GetAll()
                .Where(Comment => Comment.CreatorID != null && Comment.CreatorID.ToString() == userId)
                .AsEnumerable();
        }

        /*public void AddComment(string userId, string commentText, string gameId)
        {
            Guid userIdGuid = Guid.Empty;
            if(!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            Guid gameIdGuid = Guid.Empty;
            if (!Guid.TryParse(gameId, out gameIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var user = userRepository.GetUserByUserId(userIdGuid);

            if(user == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            var comment = commentText;

            if (comment == null)
            {
                throw new EmptyCommentException(gameIdGuid);
            }

            commentRepository.Add(new Comment() { CommentID = Guid.NewGuid(), Score = 0, GameId = gameIdGuid, CreatorID = userIdGuid, Text = commentText });
        }*/
        public void DeleteComment(string userId, string commentId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            Guid commentIdGuid = Guid.Empty;
            if (!Guid.TryParse(commentId, out commentIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var user = userRepository.GetUserByUserId(userIdGuid);

            if (user == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            if(user.IsAdmin == false)
            {
                throw new RankNotMetException(userIdGuid);
            }

            var comment = commentRepository.GetCommentByCommentId(commentIdGuid);

            commentRepository.Delete(comment);
        }

        public void DeleteGame(string userId, string GameId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            Guid gameIdGuid = Guid.Empty;
            if (!Guid.TryParse(GameId, out gameIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var user = userRepository.GetUserByUserId(userIdGuid);

            if (user == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            if (user.IsAdmin == false)
            {
                throw new RankNotMetException(userIdGuid);
            }

            var game = gameRepository.GetGameByGameId(gameIdGuid);
            foreach(Comment com in game.Comments)
            {
                var comment = commentRepository.GetCommentByCommentId(com.CommentID);
                commentRepository.Delete(comment);
            }
            gameRepository.Delete(game);
        }

        public void AddGame(string userId, string gameText)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var user = userRepository.GetUserByUserId(userIdGuid);

            if (user == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            var gameDescription = gameText;

            if (gameDescription == null)
            {
                throw new EmptyCommentException(userIdGuid);
            }

            //gameRepository.Add(new Game() { Comments = new ICollection<Comment>(), CreatorID = userIdGuid, DateCreated = 0, Description = gameText, GameID = Guid.NewGuid(), NOComments = 0, Score = 0, Title = "notitleyet" }) ; 
        }
    }
}

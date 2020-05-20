using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Exceptions;
using GameForum.ApplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameForum.ApplicationLogic.Services
{
    class GameService
    {
        private IUser userRepository;
        private Abstractions.GameService gameRepository;
        private IComment commentRepository;

        public GameService(IUser userRepository, Abstractions.GameService gameRepository, IComment commentRepository)
        {
            this.userRepository = userRepository;
            this.gameRepository = gameRepository;
            this.commentRepository = commentRepository;
        }

        public double GetGameScore(string gameId)
        {
            Guid gameIdGuid = Guid.Empty;
            if (!Guid.TryParse(gameId, out gameIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var game = gameRepository.GetGameByGameId(gameIdGuid);
            if (game == null)
            {
                throw new EntityNotFoundException(gameIdGuid);
            }

            return game.Score;
        }

        public IEnumerable<Comment> GetUserComments(string gameId)
        {
            Guid gameIdGuid = Guid.Empty;
            if (!Guid.TryParse(gameId, out gameIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return commentRepository.GetAll()
                .Where(Comment =>  Comment.GameId.ToString() == gameId)
                .AsEnumerable();
        }

        public string GetGameDescription(string gameId)
        {
            Guid gameIdGuid = Guid.Empty;
            if (!Guid.TryParse(gameId, out gameIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var game = gameRepository.GetGameByGameId(gameIdGuid);
            if (game == null)
            {
                throw new EntityNotFoundException(gameIdGuid);
            }

            return game.Description;
        }
        public string GetGameTitleById(string gameId)
        {
            Guid gameIdGuid = Guid.Empty;
            if (!Guid.TryParse(gameId, out gameIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var game = gameRepository.GetGameByGameId(gameIdGuid);
            if (game == null)
            {
                throw new EntityNotFoundException(gameIdGuid);
            }

            return game.Title;
        }
    }
}

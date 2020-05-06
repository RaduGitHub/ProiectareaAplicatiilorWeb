using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Model;
using GameForum.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameForum.EFDataAccess
{
    public class GameRepository : BaseRepository<Game>, GameService
    {
        public GameRepository(GameForumDbContext dbContext) : base(dbContext)
        {

        }

        public int GetCommentsGame(Guid CommentId, Game game)
        {
            throw new NotImplementedException();
        }

        public Guid GetCreatorId(Guid gameId)
        {
            return dbContext.Games.Where(Game => Game.GameID == gameId).Select(Game => Game.CreatorID).SingleOrDefault();
        }

        public int GetDateGame(Guid CommentId, Game game)
        {
            throw new NotImplementedException();
        }

        public int GetScoreGame(Guid CommentId, Game game)
        {
            throw new NotImplementedException();
        }

        public int GetTitleGame(Guid CommentId, Game game)
        {
            throw new NotImplementedException();
        }

        string GameService.GetCreatorId(Guid gameId)
        {
            throw new NotImplementedException();
        }

        Game GetGameByGameId(Guid gameId)
        {
            return dbContext.Games
                .Where(Game => Game.GameID == gameId)
                .SingleOrDefault();
        }

        Game GameService.GetGameByGameId(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}

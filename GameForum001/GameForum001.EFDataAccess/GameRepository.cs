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
    public class GameRepository : BaseRepository<Game>, IGame
    {
        public GameRepository(GameForumDBContext dbContext) : base(dbContext)
        {

        }

        public int GetCommentsGame(Guid CommentId, Game game)
        {
            throw new NotImplementedException();
        }

        /*public Guid GetCreatorId(int gameId)
        {
            return dbContext.Games.Where(Game => Game.GameID == gameId).Select(Game => Game.CreatorID).SingleOrDefault();
        }*/

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

        public void UpdateNOComments(Guid gameId, bool action)
        {
            var game = dbContext.Games.First(a => a.GameID == gameId);
            if(action == true)
            { 
                game.NOComments = game.NOComments + 1;
            }
            else
            {
                game.NOComments = game.NOComments - 1;
            }
            dbContext.SaveChanges();
        }

        public void UpdateScore(Guid gameId)
        {
            throw new NotImplementedException();
        }

        /*string GameService.GetCreatorId(Guid gameId)
        {
            throw new NotImplementedException();
        }*/

        /*Game GetGameByGameId(int gameId)
        {
            return dbContext.Games
                .Where(Game => Game.GameID == gameId)
                .SingleOrDefault();
        }*/

        Game IGame.GetGameByGameId(Guid gameId)
        {
            return dbContext.Games.Where(Game => Game.GameID == gameId).SingleOrDefault();
        }
    }
}

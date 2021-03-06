﻿using System;
using System.Collections.Generic;
using System.Text;
using GameForum.ApplicationLogic.Model;

namespace GameForum.ApplicationLogic.Abstractions
{
    public interface IGame : IRepository<Game>
    {
        int GetCommentsGame(Guid CommentId, Game game);
        /*string GetCreatorId(Guid gameId);*/
        int GetDateGame(Guid CommentId, Game game);
        int GetScoreGame(Guid CommentId, Game game);
        int GetTitleGame(Guid CommentId, Game game);
        Game GetGameByGameId(Guid gameId);
        void UpdateScore(Guid gameId);
        void UpdateNOComments(Guid gameId, bool action);

    }
}

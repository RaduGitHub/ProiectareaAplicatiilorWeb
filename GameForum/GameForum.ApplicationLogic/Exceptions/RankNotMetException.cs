using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.ApplicationLogic.Exceptions
{
    class RankNotMetException:Exception
    {
        public Guid EntityId { get; private set; }
        public RankNotMetException(Guid id) : base($"Entity with id {id} does not meet the rank")
        {

        }
    }
}

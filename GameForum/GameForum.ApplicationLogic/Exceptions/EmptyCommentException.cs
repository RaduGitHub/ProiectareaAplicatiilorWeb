using System;
using System.Collections.Generic;
using System.Text;

namespace GameForum.ApplicationLogic.Exceptions
{
    class EmptyCommentException:Exception
    {
        public string EntityText { get; private set; }
        public EmptyCommentException(Guid id) : base($"Text space for id {id} was not filled")
        {

        }
    }
}

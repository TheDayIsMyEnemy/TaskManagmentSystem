using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagmentSystem.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public DateTime Edited { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int TaskId { get; set; }
        public AppTask Task { get; set; }
    }
}

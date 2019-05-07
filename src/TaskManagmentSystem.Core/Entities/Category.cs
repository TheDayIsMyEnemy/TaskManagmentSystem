﻿using System.Collections.Generic;

namespace TaskManagmentSystem.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<AppTask> Tasks { get; set; }
    }
}

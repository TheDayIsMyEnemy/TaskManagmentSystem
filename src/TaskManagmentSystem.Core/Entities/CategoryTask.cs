﻿namespace TaskManagmentSystem.Core.Entities
{
    public class CategoryTask
    {
        public int TaskId { get; set; }
        public AppTask Task { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

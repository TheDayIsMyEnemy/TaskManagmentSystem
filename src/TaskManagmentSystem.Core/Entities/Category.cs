using System.Collections.Generic;

namespace TaskManagmentSystem.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<TaskCategory> Tasks { get; set; } = new List<TaskCategory>();
    }
}

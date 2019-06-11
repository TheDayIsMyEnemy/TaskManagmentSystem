using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<AppTask> Tasks { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<CategoryTask> TasksInCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppTask>(ConfigureTask);
            builder.Entity<Post>(ConfigurePost);
            builder.Entity<CategoryTask>(ConfigureCategoryTask);
            builder.Entity<Category>(ConfigureCategory);


        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired(true);

        }

        private void ConfigureCategoryTask(EntityTypeBuilder<CategoryTask> builder)
        {
            builder
                .HasKey(k => new { k.TaskId, k.CategoryId });

            builder
                .HasOne(tk => tk.Task)
                .WithMany(t => t.Categories)
                .HasForeignKey(tk => tk.TaskId);

            builder
                .HasOne(tk => tk.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(c => c.CategoryId);
        }

        private void ConfigurePost(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasOne(p => p.Task)
                .WithMany(t => t.Posts)
                .HasForeignKey(p => p.TaskId);

            builder
                .HasOne(p => p.Author)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AuthorId);
        }

        private void ConfigureTask(EntityTypeBuilder<AppTask> builder)
        {
            builder.ToTable("Task");

            builder
                .HasOne(t => t.Assignee)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssigneeId);

            builder
                .HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatorId);

            builder
                .Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired(true);

            builder
                .Property(t => t.Description)
                .HasMaxLength(250)
                .IsRequired(true);


        }
    }
}

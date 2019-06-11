using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class DbInitializer
    {
        private const string adminPassword = "admin12";
        private const string adminEmail = "admin@tms.com";

        public static async void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope
                                .ServiceProvider
                                .GetRequiredService<AppDbContext>();

                context.Database.Migrate();

                RoleManager<IdentityRole> roleManager = scope
                                                 .ServiceProvider
                                                 .GetRequiredService<RoleManager<IdentityRole>>();

                UserManager<User> userManager = scope
                                                .ServiceProvider
                                                .GetRequiredService<UserManager<User>>();

                foreach (var role in Enum.GetNames(typeof(RoleType)))
                {
                    bool roleExists = await roleManager.RoleExistsAsync(role);

                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole { Name = role });
                    }
                }

                User user = await userManager.FindByEmailAsync(adminEmail);

                if (user == null)
                {
                    user = new User() { UserName = adminEmail, Email = adminEmail };
                    var result = await userManager.CreateAsync(user, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, RoleType.Administrator.ToString());
                    }
                }
                else
                {
                    await userManager.AddToRoleAsync(user, RoleType.Administrator.ToString());
                }


                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            Name = "Uncategorized"
                        },
                        new Category
                        {
                            Name = "Support"
                        },
                        new Category
                        {
                            Name = "Sales"
                        },
                        new Category
                        {
                            Name = "SEO"
                        },
                        new Category
                        {
                            Name = "Administration"
                        },
                        new Category
                        {
                            Name = "Designs",
                        },
                        new Category
                        {
                            Name = "Production"
                        }
                        );

                    context.SaveChanges();
                }

                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(
                        new AppTask
                        {
                            Title = "Add identity roles",
                            Created = DateTime.Now,
                            Description = "Create admin, moderator and other roles",
                            DueDate = DateTime.Now.AddDays(10),
                            Priority = TaskPriority.Critical,
                            Status = Core.Entities.TaskStatus.Active,
                            CreatorId = user.Id
                        }, new AppTask
                        {
                            Title = "Random Title 1",
                            Created = DateTime.Now,
                            Description = "No description",
                            DueDate = DateTime.Now.AddDays(20),
                            Priority = TaskPriority.Major,
                            Status = Core.Entities.TaskStatus.Fixed,
                            CreatorId = user.Id
                        }, new AppTask
                        {
                            Title = "Random Title 2",
                            Created = DateTime.Now,
                            Description = "No description",
                            DueDate = DateTime.Now.AddDays(30),
                            Priority = TaskPriority.Minor,
                            Status = Core.Entities.TaskStatus.InProgress,
                            CreatorId = user.Id
                        }, new AppTask
                        {
                            Title = "Random Title 4",
                            Created = DateTime.Now,
                            Description = "No description",
                            DueDate = DateTime.Now.AddDays(40),
                            Priority = TaskPriority.Normal,
                            Status = Core.Entities.TaskStatus.Sandbox,
                            CreatorId = user.Id
                        }, new AppTask
                        {
                            Title = "Random Title 3",
                            Created = DateTime.Now,
                            Description = "No description",
                            DueDate = DateTime.Now.AddDays(7),
                            Priority = TaskPriority.ShowStopper,
                            Status = Core.Entities.TaskStatus.Verified,
                            CreatorId = user.Id
                        }
                        , new AppTask
                        {
                            Title = "Task 123",
                            Created = DateTime.Now,
                            Description = "No description",
                            DueDate = DateTime.Now.AddDays(14),
                            Priority = TaskPriority.Critical,
                            Status = Core.Entities.TaskStatus.WithErorr,
                            CreatorId = user.Id
                        }
                        );

                    context.SaveChanges();
                }

                if (!context.TasksInCategories.Any())
                {
                    context.TasksInCategories.AddRange(
                        new CategoryTask
                        {
                            CategoryId = 1,
                            TaskId = 1,
                        }, new CategoryTask
                        {
                            CategoryId = 1,
                            TaskId = 2,
                        }, new CategoryTask
                        {
                            CategoryId = 1,
                            TaskId = 3,
                        }, new CategoryTask
                        {
                            CategoryId = 1,
                            TaskId = 4,
                        }, new CategoryTask
                        {
                            CategoryId = 1,
                            TaskId = 5,
                        }, new CategoryTask
                        {
                            CategoryId = 1,
                            TaskId = 6,
                        }
                        );

                    context.SaveChanges();
                }

               
            }   
        }
    }
}

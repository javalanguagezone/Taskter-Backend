using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            //Client seeding
            modelBuilder.Entity<Client>().HasData(new Client("Tacta") { Id = 1 });

            //User seedings
            modelBuilder.Entity<User>().HasData(new User("nermin.milisic", "Nermin", "Milisic", "Domar", "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg"){Id = 1},
                new User ("selim.huskic", "Selim", "Huskic", "Kotlovnicar", "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg"){Id = 2});

            //Project seedings

            modelBuilder.Entity<Project>().HasData(
                new Project("Tracker", 1, "OU742") { Id = 1 },
                new Project("Moleraj", 1, "MOL001") { Id = 2 });

            //ProjectTasks seedings

            modelBuilder.Entity<ProjectTask>().HasData(
                new ProjectTask ("Development", 1, true){Id = 1},
                new ProjectTask ("Review", 1, true){Id = 2},
                new ProjectTask ("Marketing", 1, false){Id = 3},
                new ProjectTask ("Marketing", 1, true){Id = 4},
                new ProjectTask ("UI", 2, true){Id = 5},
                new ProjectTask ("Backend", 2, true){Id = 6},
                new ProjectTask ("Deployment", 2, true){Id = 7},
                new ProjectTask ("Audit", 2, false){Id = 8});

            //UserProject seedings

            modelBuilder.Entity<UserProject>().HasData(
                new UserProject (1,1),
                new UserProject (2,2));
            //ProjectTaskEntries

            modelBuilder.Entity<ProjectTaskEntry>().HasData(

                new ProjectTaskEntry(1, 1,1, 30, DateTime.Now, " Lorem ipsum dolor sit amet"),
                new ProjectTaskEntry(2, 1, 2,90, DateTime.Now, " Lorem ipsum dolor sit amet"),
                new ProjectTaskEntry(3, 1, 3,60, DateTime.Now, " Lorem ipsum dolor sit amet"),
                new ProjectTaskEntry(4, 1, 4,90, DateTime.Now, " Lorem ipsum dolor sit amet")
            );

        }

    }
}
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
            modelBuilder.Entity<User>().HasData(new User("nermin.milisic", "Nermin", "Milisic", "Administrator", "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg") { Id = 1 },
                new User("selim.huskic", "Selim", "Huskic", "Administrator", "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg") { Id = 2 });
        }
    }
}
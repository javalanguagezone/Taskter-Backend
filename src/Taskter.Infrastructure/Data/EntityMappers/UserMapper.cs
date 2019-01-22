using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    static class UserMapper
    {
        public static  void AddUserMapping(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
           
            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();
    
            modelBuilder.Entity<User>().Property(u => u.AvatarURL).IsRequired();
        } 
    }
}

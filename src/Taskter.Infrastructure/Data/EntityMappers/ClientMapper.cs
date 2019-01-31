using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    static class ClientMapper
    {
        public static void AddClientMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().Property(c => c.Name).IsRequired();
        }
    }
}

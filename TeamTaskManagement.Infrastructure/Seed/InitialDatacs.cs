using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Infrastructure.Seed
{
    public static class InitialData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                GetRoles()
            );
        }
        #region Role
        private static List<Role> GetRoles()
        {
            return new List<Role> {
            new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
            new Role
                {
                    Id = 2,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
            };
        }
        #endregion

    }
}

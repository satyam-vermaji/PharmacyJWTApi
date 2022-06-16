using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmacyJWTApi.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().HasData(
            new UserDetail() { UserId = 1, UserName = "varun", Email = "varun@abc.com", Password = "varum@1234", PhoneNumber = "9897124588", Address = "sector 25 nagloi delhi", Age = 20, RoleId = 1 },
            new UserDetail() { UserId = 2, UserName = "Nikhil", Email = "Nikhil@abc.com", Password = "Nikhil@1234", PhoneNumber = "9897125599", Address = "sector 20 nagloi delhi", Age = 22, RoleId = 2 }
            );
        }
    }
}

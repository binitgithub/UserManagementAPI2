using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI2.Models;

namespace UserManagementAPI2.Data
{
    public class UserManagementDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options) { }
    }
}
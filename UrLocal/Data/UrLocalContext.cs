using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Npgsql;
using Npgsql.EntityFrameworkCore;
using UrLocal;
using UrLocal.Models;

namespace Data.UrLocal
{
    public class UrLocalContext : DbContext
    {
        public UrLocalContext(DbContextOptions<UrLocalContext> options) : base(options)
        {

        }
        // sets up the particular database and links with the postgres database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=urlocaldb;User ID=henrymrrtt;Password=Ories-10;");

        // creates the database set to match that of the database tables in the database
        public DbSet<Users> users { get; set; }
        public DbSet<Bars> bars { get; set; }
        public DbSet<barScore> bar_score { get; set; }
        public DbSet<barCheck> bar_check { get; set; }
        public DbSet<userPref> user_pref { get; set; }
        public DbSet<userCheck> user_check { get; set; }
    }
}
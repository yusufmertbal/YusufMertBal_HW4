﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace YusufMertBal_HW4
{
    public class CetDb : DbContext
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=CetDb;Trusted_Connection=True;";
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public CetDb() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

﻿using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Mag.Entities
{
    public class MagContext : DbContext
    {
        string _connectionString = "Server=O-GACKI-N;Database=MeetupDb;Trusted_Connection=True;";

        DbSet<User> users { get; set; }
        DbSet<Squad> squads { get; set; }                                                       
        DbSet<Category> categories { get; set; }
        DbSet<Quality> qualities { get; set; }       
        DbSet<LoanHistory> loanHistories { get; set; }
        DbSet<Item> items { get; set; }

        /*
        Users<->Squads -Jeden do Jeden  *

        Users<->LoanHistory jeden do wielu 

        Users<->Items- Jeden do wielu  * 

        Items<->Categories- Jeden do jeden  *

        Items<->Quality- Jeden do jeden  *  

        Items<->LoanHistory- Jeden do wielu 
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Jeden do jeden

            modelBuilder.Entity<User>()
                .HasOne(m => m.Squad)
                .WithOne(l => l.User);

            modelBuilder.Entity<Item>()
                .HasOne(m => m.Quality)
                .WithOne(l => l.Item);

            modelBuilder.Entity<Item>()
                .HasOne(m => m.Category)
                .WithOne(l => l.Item);

            //Jeden do wielu

            modelBuilder.Entity<Item>()
                .HasMany(m => m.Users)
                .WithOne(l => l.Item);

            modelBuilder.Entity<Item>()
                .HasMany(m => m.LoansHistories);

                
                


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}

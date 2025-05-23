﻿using MenuProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuProject.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
                    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new
                { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(i => i.DishId);


            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margherita", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSN8GeAtB9n7it8mS7J4zIbtQvXQcLy1gjEQ&s", Price = 10.99 });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Mozzarella" });

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient{ DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 2, IngredientId = 2});


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}

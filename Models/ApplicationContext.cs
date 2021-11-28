using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelBank.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Role>().HasData(
               new Role[]
               {
                new Role {Id=1, Name="admin"},
                new Role {Id=2, Name="user"},
                new Role {Id=3, Name="userplus"}
               });
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                new User {Id=1, Email="admin@mail.ru", Password="123456", RoleId=1},
                new User {Id=2, Email="p.evsikoff@yandex.by", Password="123", RoleId=2},
                new User {Id=3, Email="user@mail.ru", Password="111", RoleId=3}
                });
            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                new Category {NameCategory="Еда", Id=1},
                new Category {NameCategory="Вкусности", Id=2},
                new Category {NameCategory="Вода", Id=3}
                });
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                new Product {Id=1, Name="Селедка", Description="Селедка соленая", Price=10000, Note="Акция", NoteSpec="Пересоленая", CategoryId=1},
                new Product {Id=2, Name="Тушенка", Description="Тушенка говяжая", Price=20000, Note="Вкусная", NoteSpec="Жилы", CategoryId=1},
                new Product {Id=3, Name="Сгущенка", Description="В банках", Price=30000, Note="С ключом", NoteSpec="Вкусная", CategoryId=2},
                new Product {Id=4, Name="Квас", Description="В бутылках", Price=15000, Note="Вятский", NoteSpec="Теплый", CategoryId=3}
                });
        }
    }
}

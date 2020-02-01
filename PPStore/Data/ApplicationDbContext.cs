using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPStore.Models;

namespace PPStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<PPUser>
    {
        public DbSet<Pizza> Pizzas { get; set; }
     
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Address { get; set; }
     


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderPizza>().HasKey(orderPizza => new {orderPizza.OrderId, orderPizza.PizzaId});
        }
    }
}

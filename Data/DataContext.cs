using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pizza_mama.Models; 

namespace pizza_mama.Data 
{
    public class DataContext : DbContext //c'est une class dans EntityFrameworkcore
    { 
        //mon constructeur, par defaut il prend option 
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        } 
        public DbSet<Pizza> Pizzas { get; set; } //et le modele que je dois lui preciser c'est le modele que je veux utiliser donc Pizza 
    }

}
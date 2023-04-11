using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ms_filmes.Model;

namespace ms_filmes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){

        }
        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options){
            
        }
        public virtual DbSet<Filme> Filmes { get; set;}
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder); 
            Builder.Entity<Filme>();
        }
    }
}